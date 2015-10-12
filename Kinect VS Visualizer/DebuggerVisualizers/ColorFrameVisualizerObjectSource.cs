using Microsoft.Kinect;
using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design;
using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class ColorFrameVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var colorFrame = (target as ColorFrame);

            if (colorFrame == null)
                return;

            var formatter = new BinaryFormatter();
            var internalColorFrame = new InternalColorFrame();

            internalColorFrame.ColorCameraSettings = new InternalColorCameraSettings()
            {
                ExposureTime = colorFrame.ColorCameraSettings.ExposureTime,
                FrameInterval = colorFrame.ColorCameraSettings.FrameInterval,
                Gain = colorFrame.ColorCameraSettings.Gain,
                Gamma = colorFrame.ColorCameraSettings.Gamma,
            };

            internalColorFrame.FrameDescription = new InternalFrameDescription()
            {
                BytesPerPixel = colorFrame.FrameDescription.BytesPerPixel,
                DiagonalFieldOfView = colorFrame.FrameDescription.DiagonalFieldOfView,
                Height = colorFrame.FrameDescription.Height,
                HorizontalFieldOfView = colorFrame.FrameDescription.HorizontalFieldOfView,
                LengthInPixels = colorFrame.FrameDescription.LengthInPixels,
                VerticalFieldOfView = colorFrame.FrameDescription.VerticalFieldOfView,
                Width = colorFrame.FrameDescription.Width,
            };

            internalColorFrame.RawColorImageFormat = (InternalColorImageFormat)colorFrame.RawColorImageFormat;
            internalColorFrame.RelativeTime = colorFrame.RelativeTime;
            internalColorFrame.Image = colorFrame.GetPixelArrayFrame();

            formatter.Serialize(outgoingData, internalColorFrame);

            outgoingData.Flush();
        }
    }
}