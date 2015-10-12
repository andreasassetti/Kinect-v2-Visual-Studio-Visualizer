using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    internal class InternalHighDefinitionFaceFrame: Internal2DFrame
    {
        [Category("HighDefinitionFaceFrame")]
        [ReadOnly(true)]
        public bool IsFaceTracked { get; set; }

        [Category("HighDefinitionFaceFrame")]
        [ReadOnly(true)]
        public bool IsTrackingIdValid { get; set; }

        [Category("HighDefinitionFaceFrame")]
        [ReadOnly(true)]
        public ulong TrackingId { get; set; }
    }
}
