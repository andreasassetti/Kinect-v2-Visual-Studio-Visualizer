using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media;

using Microsoft.Kinect;
using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;
using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class BodyFrameVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var bodyFrame = (target as BodyFrame);

            if (bodyFrame == null)
                return;

            var formatter = new BinaryFormatter();
            var internalBodyFrame = new InternalBody2DFrame();
            var frameDescription = bodyFrame.GetFrameDescription();

            internalBodyFrame.FrameDescription = new InternalFrameDescription()
            {
                BytesPerPixel = frameDescription.BytesPerPixel,
                DiagonalFieldOfView = frameDescription.DiagonalFieldOfView,
                Height = frameDescription.Height,
                HorizontalFieldOfView = frameDescription.HorizontalFieldOfView,
                LengthInPixels = frameDescription.LengthInPixels,
                VerticalFieldOfView = frameDescription.VerticalFieldOfView,
                Width = frameDescription.Width,
            };

            internalBodyFrame.BodyCount = bodyFrame.BodyCount;
            internalBodyFrame.FloorClipPlane = bodyFrame.FloorClipPlane.ToInternalVector4();
            internalBodyFrame.RelativeTime = bodyFrame.RelativeTime;

            var array = bodyFrame.GetNewPixelArray();

            bodyFrame.ToBitmapSource(true, 5, 3).CopyPixels(array, frameDescription.Width * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8), 0);
            internalBodyFrame.Image = array;

            formatter.Serialize(outgoingData, internalBodyFrame);

            outgoingData.Flush();
        }
    }
}