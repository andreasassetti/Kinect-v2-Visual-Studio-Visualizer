using System;
using System.ComponentModel;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    internal class InternalColorFrame : Internal2DFrame
    {
        [Category("ColorFrame")]
        [ReadOnly(true)]
        public InternalColorCameraSettings ColorCameraSettings { get; set; }

        [Category("ColorFrame")]
        [ReadOnly(true)]
        public InternalColorImageFormat RawColorImageFormat { get; set; }
    }
}