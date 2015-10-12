using Microsoft.Kinect;

using System.Windows.Media;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design

{
    public static class ExtensionMethodsColorFrameSource
    {
        internal static byte[] GetNewPixelArray(this ColorFrameSource colorFrameSource)
        {
            return new byte[colorFrameSource.FrameDescription.LengthInPixels * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];
        }
    }
}