using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.Kinect;
using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;
using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class InfraredFrameVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var infraredFrame = (target as InfraredFrame);

            if (infraredFrame == null)
                return;

            var formatter = new BinaryFormatter();
            var internalInfraredFrame = new InternalInfraredFrame();

            internalInfraredFrame.FrameDescription = new InternalFrameDescription()
            {
                BytesPerPixel = infraredFrame.FrameDescription.BytesPerPixel,
                DiagonalFieldOfView = infraredFrame.FrameDescription.DiagonalFieldOfView,
                Height = infraredFrame.FrameDescription.Height,
                HorizontalFieldOfView = infraredFrame.FrameDescription.HorizontalFieldOfView,
                LengthInPixels = infraredFrame.FrameDescription.LengthInPixels,
                VerticalFieldOfView = infraredFrame.FrameDescription.VerticalFieldOfView,
                Width = infraredFrame.FrameDescription.Width,
            };

            internalInfraredFrame.RelativeTime = infraredFrame.RelativeTime;
            internalInfraredFrame.Image = infraredFrame.GetPixelArrayFrame();

            formatter.Serialize(outgoingData, internalInfraredFrame);

            outgoingData.Flush();
        }
    }
}