using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.Kinect;
using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;
using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class BodyIndexFrameVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var bodyIndexFrame = (target as BodyIndexFrame);

            if (bodyIndexFrame == null)
                return;

            var formatter = new BinaryFormatter();
            var internalBodyIndexFrame = new InternalBodyIndexFrame();

            internalBodyIndexFrame.FrameDescription = new InternalFrameDescription()
            {
                BytesPerPixel = bodyIndexFrame.FrameDescription.BytesPerPixel,
                DiagonalFieldOfView = bodyIndexFrame.FrameDescription.DiagonalFieldOfView,
                Height = bodyIndexFrame.FrameDescription.Height,
                HorizontalFieldOfView = bodyIndexFrame.FrameDescription.HorizontalFieldOfView,
                LengthInPixels = bodyIndexFrame.FrameDescription.LengthInPixels,
                VerticalFieldOfView = bodyIndexFrame.FrameDescription.VerticalFieldOfView,
                Width = bodyIndexFrame.FrameDescription.Width,
            };

            internalBodyIndexFrame.RelativeTime = bodyIndexFrame.RelativeTime;
            internalBodyIndexFrame.Image = bodyIndexFrame.GetPixelArrayFrame();

            formatter.Serialize(outgoingData, internalBodyIndexFrame);

            outgoingData.Flush();
        }
    }
}