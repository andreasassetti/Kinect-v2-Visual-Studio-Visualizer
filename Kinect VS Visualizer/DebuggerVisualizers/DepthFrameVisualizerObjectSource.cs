using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.Kinect;
using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;
using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class DepthFrameVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var depthFrame = (target as DepthFrame);

            if (depthFrame == null)
                return;

            var formatter = new BinaryFormatter();
            var internalDepthFrame = new InternalDepthFrame();

            internalDepthFrame.FrameDescription = new InternalFrameDescription()
            {
                BytesPerPixel = depthFrame.FrameDescription.BytesPerPixel,
                DiagonalFieldOfView = depthFrame.FrameDescription.DiagonalFieldOfView,
                Height = depthFrame.FrameDescription.Height,
                HorizontalFieldOfView = depthFrame.FrameDescription.HorizontalFieldOfView,
                LengthInPixels = depthFrame.FrameDescription.LengthInPixels,
                VerticalFieldOfView = depthFrame.FrameDescription.VerticalFieldOfView,
                Width = depthFrame.FrameDescription.Width,
            };

            internalDepthFrame.DepthMaxReliableDistance = depthFrame.DepthMaxReliableDistance;
            internalDepthFrame.DepthMinReliableDistance = depthFrame.DepthMinReliableDistance;
            internalDepthFrame.RelativeTime = depthFrame.RelativeTime;
            internalDepthFrame.Image = depthFrame.GetPixelArrayFrame();

            formatter.Serialize(outgoingData, internalDepthFrame);

            outgoingData.Flush();
        }
    }
}