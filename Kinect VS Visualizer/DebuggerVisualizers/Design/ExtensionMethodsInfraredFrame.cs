using Microsoft.Kinect;

using System.Linq;
using System.Windows.Media;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsInfraredFrame
    {
        internal static byte[] GetNewPixelArray(this InfraredFrame infraredFrame)
        {
            return new byte[infraredFrame.FrameDescription.LengthInPixels * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];
        }

        internal static byte[] GetPixelArrayFrame(this InfraredFrame infraredFrame)
        {
            var frameData = new ushort[infraredFrame.FrameDescription.LengthInPixels];
            var pixels = infraredFrame.GetNewPixelArray();

            infraredFrame.CopyToFrameToPixelArray(ref frameData, ref pixels);

            return pixels;
        }

        internal static void CopyToFrameToPixelArray(this InfraredFrame infraredFrame, ref ushort[] frameData, ref byte[] pixels)
        {
            var pixelIndex = 0;

            infraredFrame.CopyFrameDataToArray(frameData);

            foreach (var intensity in frameData.Select(framePixel => (byte)(framePixel >> 8)))
            {
                pixels[pixelIndex++] = intensity;
                pixels[pixelIndex++] = intensity;
                pixels[pixelIndex++] = intensity;

                ++pixelIndex;
            }
        }
    }
}