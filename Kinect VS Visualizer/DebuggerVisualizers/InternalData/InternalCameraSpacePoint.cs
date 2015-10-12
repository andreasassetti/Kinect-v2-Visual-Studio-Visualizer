using System; 
using System.ComponentModel;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    public class InternalCameraSpacePoint
    {
        public InternalCameraSpacePoint()
        {
            X = 0.0F;
            Y = 0.0F;
            Z = 0.0F;
        }

        public InternalCameraSpacePoint(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        [ReadOnly(true)]
        public float X { get; set; }

        [ReadOnly(true)]
        public float Y { get; set; }

        [ReadOnly(true)]
        public float Z { get; set; }
    }
}