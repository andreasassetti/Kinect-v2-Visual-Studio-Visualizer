using System.Windows.Media;


using Microsoft.Kinect;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsBodyIndexFrame
    {
        internal static byte[] GetNewPixelArray(this BodyIndexFrame bodyIndexFrame)
        {
            return new byte[bodyIndexFrame.FrameDescription.LengthInPixels * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];
        }

        internal static byte[] GetPixelArrayFrame(this BodyIndexFrame bodyIndexFrame)
        {
            var frameData = new byte[bodyIndexFrame.FrameDescription.LengthInPixels];
            var pixels = bodyIndexFrame.GetNewPixelArray();

            bodyIndexFrame.CopyToFrameToPixelArray(ref frameData, ref pixels);

            return pixels;
        }

        internal static void CopyToFrameToPixelArray(this BodyIndexFrame bodyIndexFrame, ref byte[] frameData, ref byte[] pixels)
        {
            var pixelIndex = 0;

            bodyIndexFrame.CopyFrameDataToArray(frameData);

            for (int i = 0; i < frameData.Length; ++i)
            {
                var color = BodyIndexColor.GetColorFromBodyIndex(frameData[i]);
                
                pixels[pixelIndex++] = color.B;
                pixels[pixelIndex++] = color.G;
                pixels[pixelIndex++] = color.R;
                pixels[pixelIndex++] = color.A;
            }
        }
    }
}