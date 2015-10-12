using System;
using System.ComponentModel;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    internal abstract class Internal2DFrame : InternalFrame
    {
        protected Internal2DFrame()
        {
            FrameDescription = new InternalFrameDescription();
            Image = new byte[0];
        }

        [Category("Frame")]
        [ReadOnly(true)]
        public virtual InternalFrameDescription FrameDescription { get; set; }


        [Category("Frame")]
        [Browsable(false)]
        public byte[] Image { get; set; }
    }
}