using System.Windows.Media;
using System.Windows.Media.Imaging;

using Microsoft.Kinect;
using Microsoft.Kinect.Face;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsHighDefinitionFaceFrame
    {
        internal static FrameDescription GetFrameDescription(this HighDefinitionFaceFrame highDefinitionFaceFrame, bool useDepthSpace = true)
        {
            if (useDepthSpace)
                return highDefinitionFaceFrame.HighDefinitionFaceFrameSource.KinectSensor.DepthFrameSource.FrameDescription;
            else
                return highDefinitionFaceFrame.HighDefinitionFaceFrameSource.KinectSensor.ColorFrameSource.FrameDescription;
        }

        internal static byte[] GetNewPixelArray(this HighDefinitionFaceFrame highDefinitionFaceFrame, bool useDepthSpace = true)
        {
            if (useDepthSpace)
                return highDefinitionFaceFrame.HighDefinitionFaceFrameSource.KinectSensor.DepthFrameSource.GetNewPixelArray();
            else
                return highDefinitionFaceFrame.HighDefinitionFaceFrameSource.KinectSensor.ColorFrameSource.GetNewPixelArray();
        }

        internal static void CopyToFrameToDrawingGroup(this HighDefinitionFaceFrame highDefinitionFaceFrame, ref DrawingVisual drawingVisual, bool useDepthSpace = true, byte bodyIndex = 1, double pointRadius = 2F)
        {
            drawingVisual.Children.Clear();

            using (DrawingContext context = drawingVisual.RenderOpen())
            {
                highDefinitionFaceFrame.CopyToFrameToDrawingContext(context, useDepthSpace, bodyIndex, pointRadius);
            }
        }

        internal static void CopyToFrameToDrawingContext(this HighDefinitionFaceFrame highDefinitionFaceFrame, DrawingContext context, bool useDepthSpace = true, byte bodyIndex = 1, double pointRadius = 2F)
        {
            var faceAlignment = new FaceAlignment();
            var coordinateMapper = highDefinitionFaceFrame.HighDefinitionFaceFrameSource.KinectSensor.CoordinateMapper;
            var brush = BodyIndexColor.GetBrushFromBodyIndex(bodyIndex);

            highDefinitionFaceFrame.GetAndRefreshFaceAlignmentResult(faceAlignment);

            var faceModel = new FaceModel();
            var vertices = faceModel.CalculateVerticesForAlignment(faceAlignment);

            if (vertices.Count > 0)
            {
                for (int index = 0; index < vertices.Count; index++)
                {
                    CameraSpacePoint vertice = vertices[index];
                    DepthSpacePoint point = coordinateMapper.MapCameraPointToDepthSpace(vertice);

                    if (float.IsInfinity(point.X) || float.IsInfinity(point.Y))
                        return;

                    context.DrawEllipse(brush, null, point.GetPoint(), pointRadius, pointRadius);
                }
            }
        }

        internal static DrawingVisual GetDrawingGroup(this HighDefinitionFaceFrame highDefinitionFaceFrame, bool useDepthSpace = true, byte bodyIndex = 1, double pointRadius = 2F)
        {
            var bodyDrawingGroup = new DrawingVisual();

            highDefinitionFaceFrame.CopyToFrameToDrawingGroup(ref bodyDrawingGroup, useDepthSpace, bodyIndex, pointRadius);

            return bodyDrawingGroup;
        }

        public static BitmapSource ToBitmapSource(this HighDefinitionFaceFrame highDefinitionFaceFrame, byte bodyIndex = 1, double pointRadius = 2F)
        {
            var frameDescription = highDefinitionFaceFrame.HighDefinitionFaceFrameSource.KinectSensor.DepthFrameSource.FrameDescription;
            var renderTargetBitmap = new RenderTargetBitmap(frameDescription.Width, frameDescription.Height, 96.0, 96.0, PixelFormats.Pbgra32);
            var drawingGroup = highDefinitionFaceFrame.GetDrawingGroup(true, bodyIndex, pointRadius);

            renderTargetBitmap.Render(drawingGroup);

            return renderTargetBitmap;
        }
    }
}
