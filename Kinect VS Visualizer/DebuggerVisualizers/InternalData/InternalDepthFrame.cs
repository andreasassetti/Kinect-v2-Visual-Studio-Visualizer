using System;
using System.ComponentModel;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    internal class InternalDepthFrame : Internal2DFrame
    {
        public InternalDepthFrame()
        {
            DepthMaxReliableDistance = 0;
            DepthMinReliableDistance = 0;
        }

        [Category("DepthFrame")]
        [ReadOnly(true)]
        public ushort DepthMaxReliableDistance { get; set; }

        [Category("DepthFrame")]
        [ReadOnly(true)]
        public ushort DepthMinReliableDistance { get; set; }
    }
}