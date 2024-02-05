# MVSDK C#

This is a C# wrapper for [Huaray (iRAYPLE)](https://www.irayple.com) MVSDK C library,
similar to the provided `MVSDK_Net.dll` and `MVSDKFG_Net.dll` provided by iRAYPLE.

However this library have C structs processed into magaged class and structs for
easier use.

# Requirements

This is just a wrapper of the provided C library, you have to install `MVViewer Client`
(or get the lib by other methods) before you can use this library.

Official `MVViewer Client` can be downloaded from [Huaray (iRAYPLE)](https://www.irayple.com)
website, the latest version tested is `v2.4.1` (2023-11-22).

# Usage
## Native Library Version
```C#
var version = HuarayLibrary.Version;
```

## Enumerate devices
```C#
// scan from all interface types
DeviceEnumerator.Enumerate();
// scan only usb3 devices
DeviceEnumerator.Enumerate(InterfaceType.USB3);
// scan PCIe and GigE devices
DeviceEnumerator.Enumerate(InterfaceType.PCIe | InterfaceType.GigE);
// unicast scanning
DeviceEnumerator.Enumerate(IPAddress.Parse("192.168.1.10"));
```

## Create and connect to the camera
```C#
var camera = new VideoCaptrue(IPAddress.Parse("192.168.1.10"));
// or
var camera = new VideoCapture("...", CreateHandleMode.ByCameraKey);
var camera = new VideoCapture("...", CreateHandleMode.ByUserDefinedName);
var camera = new VideoCapture(0); // by scan index, not recommanded.

// change the IP address of the camera (GigE) if required
//camera.ForceIP(...);

/* call open to actually connect to the camera */
camera.Open();
```
When creating the `VideoCapture` instance with `CreateHandleMode` other than `ByScanIndex`,
the lib will scan for cameras with `DeviceEnumerator.Enumerate(InterfaceType.All)`.

If you want to create the `VideoCapture` instance by index, do a scan first yourself, or
`StatusCode.InvalidResource` because no camera information is in the native cache.

## Streaming
```C#
// attach event handler
camera.FrameGrabbed += (sender, e) => 
{
    /* do something with the frame */
};

// start streaming
camera.StartGrabbing();

/* `camera.FrameGrabbed` event will be invoked. */

// stop streaming
camera.StopGrabbing();
```

## Recording
```C#
// attach event handler
camera.FrameGrabbed += (sender, e) =>
{
    var camera = (VideoCapture)sender;
    camera.RecordFrame(e);
};

// prepare for recording
camera.StartRecording(...);
// start streaming
camera.StartGrabbing();

/* `camera.FrameGrabbed` event will be invoked. */

// stop streaming
camera.StopGrabbing();
// end recording
camera.StopRecording();
```

## Clean-up
```C#
camera.Close(); // disconnect
camera.Dispose(); // don't forget to dispose native resources when you're done
```

# TODO
- more `StandardFeatures`, currently I just added the ones I use.
- wrap `IMV_FG_*` for CameraLink devices

# Disclaimer

**The author of this software is not affiliated with
[Zhejiang Huaray (iRAYPLE) Cooperation](https://www.irayple.com) in any way. All
trademarks and registered trademarks are property of their respective owners,
and company, product and service names mentioned in this readme or appearing in
source code or other artifacts in this repository are used for identification
purposes only.**

**Use of these names does not imply endorsement by either
[Zhejiang Huaray (iRAYPLE) Cooperation](https://www.irayple.com).**

# Reference
1. https://github.com/harboleas/mvsdk_sharp
2. https://www.emva.org/standards-technology/genicam/