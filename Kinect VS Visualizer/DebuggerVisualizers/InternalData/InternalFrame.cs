using System;
using System.ComponentModel;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    internal abstract class InternalFrame
    {
        protected InternalFrame()
        {
            RelativeTime = new TimeSpan();
        }

        [Category("Frame")]
        [ReadOnly(true)]
        public TimeSpan RelativeTime { get; set; }
    }
}