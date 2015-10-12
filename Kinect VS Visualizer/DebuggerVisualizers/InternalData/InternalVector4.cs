using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    [TypeConverter(typeof(InternalVector4Converter)), ComVisible(true)]
    internal class InternalVector4
    {
        public InternalVector4()
        {
            W = 0.0F;
            X = 0.0F;
            Y = 0.0F;
            Z = 0.0F;
        }

        public InternalVector4(float w, float x, float y, float z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        [ReadOnly(true)]
        public float W { get; set; }

        [ReadOnly(true)]
        public float X { get; set; }

        [ReadOnly(true)]
        public float Y { get; set; }

        [ReadOnly(true)]
        public float Z { get; set; }
    }
}