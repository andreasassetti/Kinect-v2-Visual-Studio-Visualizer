using Microsoft.Kinect;

using System.Windows.Media;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsColorFrame
    {
        internal static byte[] GetNewPixelArray(this ColorFrame colorFrame)
        {
            return new byte[colorFrame.FrameDescription.LengthInPixels * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];
        }

        internal static byte[] GetPixelArrayFrame(this ColorFrame colorFrame)
        {
            var pixels = colorFrame.GetNewPixelArray();

            colorFrame.CopyToFrameToPixelArray(ref pixels);

            return pixels;
        }

        internal static void CopyToFrameToPixelArray(this ColorFrame colorFrame, ref byte[] pixels)
        {
            if (colorFrame.RawColorImageFormat == ColorImageFormat.Bgra)
                colorFrame.CopyRawFrameDataToArray(pixels);
            else
                colorFrame.CopyConvertedFrameDataToArray(pixels, ColorImageFormat.Bgra);
        }
    }
}