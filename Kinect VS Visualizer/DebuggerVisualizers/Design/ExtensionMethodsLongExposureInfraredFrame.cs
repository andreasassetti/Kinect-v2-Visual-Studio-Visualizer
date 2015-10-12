using Microsoft.Kinect;

using System.Linq;
using System.Windows.Media;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsLongExposureInfraredFrame
    {
        internal static byte[] GetNewPixelArray(this LongExposureInfraredFrame longExposureInfraredFrame)
        {
            return new byte[longExposureInfraredFrame.FrameDescription.LengthInPixels * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];
        }

        internal static byte[] GetPixelArrayFrame(this LongExposureInfraredFrame longExposureInfraredFrame)
        {
            var frameData = new ushort[longExposureInfraredFrame.FrameDescription.LengthInPixels];
            var pixels = longExposureInfraredFrame.GetNewPixelArray();

            longExposureInfraredFrame.CopyToFrameToPixelArray(ref frameData, ref pixels);

            return pixels;
        }

        internal static void CopyToFrameToPixelArray(this LongExposureInfraredFrame longExposureInfraredFrame, ref ushort[] frameData, ref byte[] pixels)
        {
            var pixelIndex = 0;

            longExposureInfraredFrame.CopyFrameDataToArray(frameData);

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