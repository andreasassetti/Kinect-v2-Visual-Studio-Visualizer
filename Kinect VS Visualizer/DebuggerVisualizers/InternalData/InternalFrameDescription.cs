using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    [TypeConverter(typeof(InternalFrameDescriptionConverter)), ComVisible(true)]
    internal class InternalFrameDescription
    {
        public InternalFrameDescription()
        {

        }

        public InternalFrameDescription(uint bytesPerPixel, float diagonalFieldOfView, int height, float horizontalFieldOfView, uint lengthInPixels, float verticalFieldOfView, int width)
        {
            BytesPerPixel = bytesPerPixel;
            DiagonalFieldOfView = diagonalFieldOfView;
            Height = height;
            HorizontalFieldOfView = horizontalFieldOfView;
            LengthInPixels = lengthInPixels;
            VerticalFieldOfView = verticalFieldOfView;
            Width = width;
        }

        public uint BytesPerPixel { get; set; }
        public float DiagonalFieldOfView { get; set; }
        public int Height { get; set; }
        public float HorizontalFieldOfView { get; set; }
        public uint LengthInPixels { get; set; }
        public float VerticalFieldOfView { get; set; }
        public int Width { get; set; }
    }
}