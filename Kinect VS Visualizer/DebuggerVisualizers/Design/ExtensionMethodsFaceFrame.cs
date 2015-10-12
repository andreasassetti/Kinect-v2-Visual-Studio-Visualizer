using System.Windows.Media;
using System.Windows.Media.Imaging;

using Microsoft.Kinect;
using Microsoft.Kinect.Face;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsFaceFrame
    {
        internal static FrameDescription GetFrameDescription(this FaceFrame faceFrame, bool useInfraredSpace = true)
        {
            if (useInfraredSpace)
            {
                return faceFrame.FaceFrameSource.KinectSensor.InfraredFrameSource.FrameDescription;
            }
            else
            {
                return faceFrame.FaceFrameSource.KinectSensor.ColorFrameSource.FrameDescription;
            }
        }

        internal static byte[] GetNewPixelArray(this FaceFrame faceFrame, bool useInfraredSpace = true)
        {
            if (useInfraredSpace)
            {
                return faceFrame.FaceFrameSource.KinectSensor.DepthFrameSource.GetNewPixelArray();
            }
            else
            {
                return faceFrame.FaceFrameSource.KinectSensor.ColorFrameSource.GetNewPixelArray();
            }
        }

        internal static void CopyToFrameToDrawingGroup(this FaceFrame faceFrame, ref DrawingVisual drawingVisual, bool useInfraredSpace = true, byte bodyIndex = 1, double pointRadius = 1F, double line = 1F)
        {
            drawingVisual.Children.Clear();

            using (DrawingContext context = drawingVisual.RenderOpen())
            {
                faceFrame.CopyToFrameToDrawingContext(context, useInfraredSpace, bodyIndex, pointRadius, line);
            }
        }

        internal static void CopyToFrameToDrawingContext(this FaceFrame faceFrame, DrawingContext context, bool useInfraredSpace = true, byte bodyIndex = 1, double pointRadius = 1F, double line = 1F)
        {
            var brush = BodyIndexColor.GetBrushFromBodyIndex(bodyIndex);
            var pen = new System.Windows.Media.Pen(brush, line);

            if (useInfraredSpace)
            {
                if ((faceFrame.FaceFrameResult.FaceFrameFeatures & FaceFrameFeatures.BoundingBoxInInfraredSpace) == FaceFrameFeatures.BoundingBoxInInfraredSpace)
                {
                    context.DrawRectangle(null, pen, faceFrame.FaceFrameResult.FaceBoundingBoxInInfraredSpace.ToRect());
                }

                if ((faceFrame.FaceFrameResult.FaceFrameFeatures & FaceFrameFeatures.PointsInInfraredSpace) == FaceFrameFeatures.PointsInInfraredSpace)
                {
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInInfraredSpace[FacePointType.EyeLeft].ToPoint(), pointRadius, pointRadius);
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInInfraredSpace[FacePointType.EyeRight].ToPoint(), pointRadius, pointRadius);
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInInfraredSpace[FacePointType.Nose].ToPoint(), pointRadius, pointRadius);
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInInfraredSpace[FacePointType.MouthCornerLeft].ToPoint(), pointRadius, pointRadius);
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInInfraredSpace[FacePointType.MouthCornerRight].ToPoint(), pointRadius, pointRadius);

                    context.DrawLine(pen, faceFrame.FaceFrameResult.FacePointsInInfraredSpace[FacePointType.MouthCornerLeft].ToPoint(), faceFrame.FaceFrameResult.FacePointsInInfraredSpace[FacePointType.MouthCornerRight].ToPoint());
                }
            }
            else
            {
                if ((faceFrame.FaceFrameResult.FaceFrameFeatures & FaceFrameFeatures.BoundingBoxInColorSpace) == FaceFrameFeatures.BoundingBoxInColorSpace)
                {
                    context.DrawRectangle(null, pen, faceFrame.FaceFrameResult.FaceBoundingBoxInColorSpace.ToRect());
                }

                if ((faceFrame.FaceFrameResult.FaceFrameFeatures & FaceFrameFeatures.PointsInColorSpace) == FaceFrameFeatures.PointsInColorSpace)
                {
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInColorSpace[FacePointType.EyeLeft].ToPoint(), pointRadius, pointRadius);
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInColorSpace[FacePointType.EyeRight].ToPoint(), pointRadius, pointRadius);
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInColorSpace[FacePointType.Nose].ToPoint(), pointRadius, pointRadius);
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInColorSpace[FacePointType.MouthCornerLeft].ToPoint(), pointRadius, pointRadius);
                    context.DrawEllipse(brush, null, faceFrame.FaceFrameResult.FacePointsInColorSpace[FacePointType.MouthCornerRight].ToPoint(), pointRadius, pointRadius);

                    context.DrawLine(pen, faceFrame.FaceFrameResult.FacePointsInColorSpace[FacePointType.MouthCornerLeft].ToPoint(), faceFrame.FaceFrameResult.FacePointsInColorSpace[FacePointType.MouthCornerRight].ToPoint());
                }
            }
        }

        internal static DrawingVisual GetDrawingGroup(this FaceFrame faceFrame, bool useInfraredSpace = true, byte bodyIndex = 1, double pointRadius = 1F, double line = 1F)
        {
            var bodyDrawingGroup = new DrawingVisual();

            faceFrame.CopyToFrameToDrawingGroup(ref bodyDrawingGroup, useInfraredSpace, bodyIndex, pointRadius, line);

            return bodyDrawingGroup;
        }

        public static BitmapSource ToBitmapSource(this FaceFrame faceFrame, bool useInfraredSpace = true, byte bodyIndex = 1, double pointRadius = 1F, double line = 1F)
        {
            FrameDescription frameDescription;

            if (useInfraredSpace)
            {
                frameDescription = faceFrame.FaceFrameSource.KinectSensor.DepthFrameSource.FrameDescription;
            }
            else
            {
                frameDescription = faceFrame.FaceFrameSource.KinectSensor.ColorFrameSource.FrameDescription;
            }

            var renderTargetBitmap = new RenderTargetBitmap(frameDescription.Width, frameDescription.Height, 96.0, 96.0, PixelFormats.Pbgra32);
            var drawingGroup = faceFrame.GetDrawingGroup(useInfraredSpace, bodyIndex, pointRadius, line);

            renderTargetBitmap.Render(drawingGroup);

            return renderTargetBitmap;
        }
    }
}