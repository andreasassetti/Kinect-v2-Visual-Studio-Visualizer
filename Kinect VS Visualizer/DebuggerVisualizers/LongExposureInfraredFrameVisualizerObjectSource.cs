using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.Kinect;
using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;
using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class LongExposureInfraredFrameVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var longExposureInfraredFrame = (target as LongExposureInfraredFrame);

            if (longExposureInfraredFrame == null)
                return;

            var formatter = new BinaryFormatter();
            var internalLongExposureInfraredFrame = new InternalLongExposureInfraredFrame();

            internalLongExposureInfraredFrame.FrameDescription = new InternalFrameDescription()
            {
                BytesPerPixel = longExposureInfraredFrame.FrameDescription.BytesPerPixel,
                DiagonalFieldOfView = longExposureInfraredFrame.FrameDescription.DiagonalFieldOfView,
                Height = longExposureInfraredFrame.FrameDescription.Height,
                HorizontalFieldOfView = longExposureInfraredFrame.FrameDescription.HorizontalFieldOfView,
                LengthInPixels = longExposureInfraredFrame.FrameDescription.LengthInPixels,
                VerticalFieldOfView = longExposureInfraredFrame.FrameDescription.VerticalFieldOfView,
                Width = longExposureInfraredFrame.FrameDescription.Width,
            };

            internalLongExposureInfraredFrame.RelativeTime = longExposureInfraredFrame.RelativeTime;
            internalLongExposureInfraredFrame.Image = longExposureInfraredFrame.GetPixelArrayFrame();

            formatter.Serialize(outgoingData, internalLongExposureInfraredFrame);

            outgoingData.Flush();
        }
    }
}