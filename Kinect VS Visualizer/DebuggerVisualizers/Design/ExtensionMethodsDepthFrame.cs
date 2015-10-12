using Microsoft.Kinect;

using System.Linq;
using System.Windows.Media;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsDepthFrame
    {
        internal static byte[] GetNewPixelArray(this DepthFrame depthFrame)
        {
            return new byte[depthFrame.FrameDescription.LengthInPixels * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];

        }

        internal static byte[] GetPixelArrayFrame(this DepthFrame depthFrame)
        {
            var frameData = new ushort[depthFrame.FrameDescription.LengthInPixels];
            var pixels = depthFrame.GetNewPixelArray();

            depthFrame.CopyToFrameToPixelArray(ref frameData, ref pixels);

            return pixels;
        }

        internal static void CopyToFrameToPixelArray(this DepthFrame depthFrame, ref ushort[] frameData, ref byte[] pixels)
        {
            var pixelIndex = 0;

            depthFrame.CopyFrameDataToArray(frameData);

            var minDepth = depthFrame.DepthMinReliableDistance;
            var maxDepth = depthFrame.DepthMaxReliableDistance;

            foreach (var intensity in frameData.Select(depth => (byte)(depth >= minDepth && depth <= maxDepth ? depth : 0)))
            {
                pixels[pixelIndex++] = intensity;
                pixels[pixelIndex++] = intensity;
                pixels[pixelIndex++] = intensity;

                ++pixelIndex;
            }
        }
    }
}