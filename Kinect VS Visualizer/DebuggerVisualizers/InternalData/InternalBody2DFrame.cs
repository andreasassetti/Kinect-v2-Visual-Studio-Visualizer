using System;
using System.ComponentModel;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    internal class InternalBody2DFrame : Internal2DFrame
    {
        public InternalBody2DFrame()
        {
        }

        [Category("BodyFrame")]
        [ReadOnly(true)]
        public int BodyCount { get; set; }

        [Category("BodyFrame")]
        [ReadOnly(true)]
        public InternalVector4 FloorClipPlane { get; set; }

        [Category("Frame")]
        [ReadOnly(true)]
        [Browsable(false)]
        public override InternalFrameDescription FrameDescription { get; set; }
    }
}