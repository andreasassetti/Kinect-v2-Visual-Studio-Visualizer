using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.Kinect.Face;
using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;
using MyFramework.Kinect;
using System.Windows.Media;
using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class HighDefinitionFaceFrameVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var highDefinitionFaceFrame = (target as HighDefinitionFaceFrame);

            if (highDefinitionFaceFrame == null)
                return;

            var formatter = new BinaryFormatter();
            var internalFaceFrame = new InternalHighDefinitionFaceFrame();

            bool useInfraredSpace = true;

            //if ((highDefinitionFaceFrame.FaceFrameResult.FaceFrameFeatures & FaceFrameFeatures.PointsInColorSpace) == FaceFrameFeatures.PointsInColorSpace ||
            //    (highDefinitionFaceFrame.FaceFrameResult.FaceFrameFeatures & FaceFrameFeatures.BoundingBoxInColorSpace) == FaceFrameFeatures.BoundingBoxInColorSpace)
            //{
            //    useInfraredSpace = false;
            //}

            //highDefinitionFaceFrame.FaceAlignmentQuality

            var frameDescription = highDefinitionFaceFrame.GetFrameDescription(useInfraredSpace);

            internalFaceFrame.FrameDescription = new InternalFrameDescription()
            {
                BytesPerPixel = frameDescription.BytesPerPixel,
                DiagonalFieldOfView = frameDescription.DiagonalFieldOfView,
                Height = frameDescription.Height,
                HorizontalFieldOfView = frameDescription.HorizontalFieldOfView,
                LengthInPixels = frameDescription.LengthInPixels,
                VerticalFieldOfView = frameDescription.VerticalFieldOfView,
                Width = frameDescription.Width,
            };

            internalFaceFrame.IsFaceTracked = highDefinitionFaceFrame.IsFaceTracked;
            internalFaceFrame.IsTrackingIdValid = highDefinitionFaceFrame.IsTrackingIdValid;
            internalFaceFrame.TrackingId = highDefinitionFaceFrame.TrackingId;
            internalFaceFrame.RelativeTime = highDefinitionFaceFrame.RelativeTime;

            var array = highDefinitionFaceFrame.GetNewPixelArray(useInfraredSpace);

            highDefinitionFaceFrame.ToBitmapSource(1, 5).CopyPixels(array, frameDescription.Width * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8), 0);
            internalFaceFrame.Image = array;

            formatter.Serialize(outgoingData, internalFaceFrame);

            outgoingData.Flush();
        }
    }
}