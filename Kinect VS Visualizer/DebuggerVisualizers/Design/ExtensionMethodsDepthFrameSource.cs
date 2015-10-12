using Microsoft.Kinect;

using System.Windows.Media;

namespace MyFramework.Kinect
{
    public static class ExtensionMethodsDepthFrameSource
    {
        internal static byte[] GetNewPixelArray(this DepthFrameSource depthFrame)
        {
            return new byte[depthFrame.FrameDescription.LengthInPixels * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];
        }
    }
}