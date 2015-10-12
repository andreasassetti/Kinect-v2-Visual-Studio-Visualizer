using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    [TypeConverter(typeof(InternalRectIConverter)), ComVisible(true)]
    internal class InternalRectI
    {
        public InternalRectI()
        {
            Bottom = 0;
            Left = 0;
            Right = 0;
            Top = 0;
        }

        public InternalRectI(int bottom, int left, int right, int top)
        {
            Bottom = bottom;
            Left = left;
            Right = right;
            Top = top;
        }

        [ReadOnly(true)]
        public int Bottom { get; set; }

        [ReadOnly(true)]
        public int Left { get; set; }

        [ReadOnly(true)]
        public int Right { get; set; }

        [ReadOnly(true)]
        public int Top { get; set; }
    }
}