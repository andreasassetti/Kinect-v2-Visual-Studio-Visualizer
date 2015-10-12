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
    internal class FaceFrameVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var faceFrame = (target as FaceFrame);

            if (faceFrame == null)
                return;

            var formatter = new BinaryFormatter();
            var internalFaceFrame = new InternalFaceFrame();

            bool useInfraredSpace = true;

            if ((faceFrame.FaceFrameResult.FaceFrameFeatures & FaceFrameFeatures.PointsInColorSpace) == FaceFrameFeatures.PointsInColorSpace ||
                (faceFrame.FaceFrameResult.FaceFrameFeatures & FaceFrameFeatures.BoundingBoxInColorSpace) == FaceFrameFeatures.BoundingBoxInColorSpace)
            {
                useInfraredSpace = false;
            }

            var frameDescription = faceFrame.GetFrameDescription(useInfraredSpace);

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

            internalFaceFrame.FaceEngaged = (InternalDetectionResult)faceFrame.FaceFrameResult.FaceProperties[FaceProperty.Engaged];
            internalFaceFrame.FaceHappy = (InternalDetectionResult)faceFrame.FaceFrameResult.FaceProperties[FaceProperty.Happy];
            internalFaceFrame.FaceLeftEyeClosed = (InternalDetectionResult)faceFrame.FaceFrameResult.FaceProperties[FaceProperty.LeftEyeClosed];
            internalFaceFrame.FaceLookingAway = (InternalDetectionResult)faceFrame.FaceFrameResult.FaceProperties[FaceProperty.LookingAway];
            internalFaceFrame.FaceMouthMoved = (InternalDetectionResult)faceFrame.FaceFrameResult.FaceProperties[FaceProperty.MouthMoved];
            internalFaceFrame.FaceMouthOpen = (InternalDetectionResult)faceFrame.FaceFrameResult.FaceProperties[FaceProperty.MouthOpen];
            internalFaceFrame.FaceRightEyeClosed = (InternalDetectionResult)faceFrame.FaceFrameResult.FaceProperties[FaceProperty.RightEyeClosed];
            internalFaceFrame.FaceWearingGlasses = (InternalDetectionResult)faceFrame.FaceFrameResult.FaceProperties[FaceProperty.WearingGlasses];
            internalFaceFrame.TrackingId = faceFrame.TrackingId;
            internalFaceFrame.RelativeTime = faceFrame.RelativeTime;
            internalFaceFrame.FaceRotationQuaternion = faceFrame.FaceFrameResult.FaceRotationQuaternion.ToInternalVector4();

            var array = faceFrame.GetNewPixelArray(useInfraredSpace);

            faceFrame.ToBitmapSource(useInfraredSpace, 1, 5, 3).CopyPixels(array, frameDescription.Width * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8), 0);
            internalFaceFrame.Image = array;

            formatter.Serialize(outgoingData, internalFaceFrame);

            outgoingData.Flush();
        }
    }
}