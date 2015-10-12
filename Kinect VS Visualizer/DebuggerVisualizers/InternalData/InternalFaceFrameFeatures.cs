using System;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Flags]
    public enum InternalFaceFrameFeatures
    {
        None = 0,
        BoundingBoxInInfraredSpace = 1,
        PointsInInfraredSpace = 2,
        BoundingBoxInColorSpace = 4,
        PointsInColorSpace = 8,
        RotationOrientation = 16,
        Happy = 32,
        RightEyeClosed = 64,
        LeftEyeClosed = 128,
        MouthOpen = 256,
        MouthMoved = 512,
        LookingAway = 1024,
        Glasses = 2048,
        FaceEngagement = 4096
    }
}