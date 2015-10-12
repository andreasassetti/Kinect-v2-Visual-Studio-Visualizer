using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Microsoft.Kinect;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsBodyFrame
    {
        internal static FrameDescription GetFrameDescription(this BodyFrame bodyFrame, bool useDepthSpace = true)
        {
            return bodyFrame.BodyFrameSource.KinectSensor.DepthFrameSource.FrameDescription;
        }

        internal static byte[] GetNewPixelArray(this BodyFrame bodyFrame)
        {
            return bodyFrame.BodyFrameSource.KinectSensor.DepthFrameSource.GetNewPixelArray();
        }

        internal static void CopyToFrameToDrawingGroup(this BodyFrame bodyFrame, ref DrawingVisual drawingVisual, bool drawBones = true, bool useDepthSpace = true, double pointRadius = 3F, double line = 0.8F)
        {
            drawingVisual.Children.Clear();

            using (DrawingContext context = drawingVisual.RenderOpen())
            {
                bodyFrame.CopyToFrameToDrawingContext(context, drawBones, useDepthSpace, pointRadius, line);
            }
        }

        internal static void CopyToFrameToDrawingContext(this BodyFrame bodyFrame, DrawingContext context, bool drawBones = true, bool useDepthSpace = true, double pointRadius = 3F, double line = 0.8F)
        {
            var bodies = new Body[bodyFrame.BodyCount];
            var coordinateMapper = bodyFrame.BodyFrameSource.KinectSensor.CoordinateMapper;
            var trnsparentPen = new System.Windows.Media.Pen(System.Windows.Media.Brushes.Transparent, 1F);

            System.Windows.Rect rect;

            if (useDepthSpace)
                rect = bodyFrame.BodyFrameSource.KinectSensor.DepthFrameSource.FrameDescription.GetRect();
            else
                rect = bodyFrame.BodyFrameSource.KinectSensor.ColorFrameSource.FrameDescription.GetRect();

            context.DrawRectangle(System.Windows.Media.Brushes.Transparent, null, rect);

            bodyFrame.GetAndRefreshBodyData(bodies);

            for (int i = 0; i < bodies.Length; i++)
            {
                if (!bodies[i].IsTracked)
                    continue;

                var brush = BodyIndexColor.GetBrushFromBodyIndex(i);

                foreach (Joint joint in bodies[i].Joints.Values.Where(j => j.TrackingState == TrackingState.Tracked))
                {
                    System.Windows.Point point;

                    if (useDepthSpace)
                        point = coordinateMapper.MapCameraPointToDepthSpace(joint.Position).GetPoint();
                    else
                        point = coordinateMapper.MapCameraPointToColorSpace(joint.Position).GetPoint();

                    if (rect.Contains(point))
                        context.DrawEllipse(brush, null, point, pointRadius, pointRadius);
                }

                if (drawBones)
                {
                    DrawBone(context, brush, JointType.Head, JointType.Neck, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.Neck, JointType.SpineShoulder, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.SpineShoulder, JointType.SpineMid, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.SpineMid, JointType.SpineBase, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.SpineShoulder, JointType.ShoulderRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.SpineShoulder, JointType.ShoulderLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.SpineBase, JointType.HipRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.SpineBase, JointType.HipLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.ShoulderRight, JointType.ElbowRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.ElbowRight, JointType.WristRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.WristRight, JointType.HandRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.HandRight, JointType.HandTipRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.WristRight, JointType.ThumbRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.ShoulderLeft, JointType.ElbowLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.ElbowLeft, JointType.WristLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.WristLeft, JointType.HandLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.HandLeft, JointType.HandTipLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.WristLeft, JointType.ThumbLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.HipRight, JointType.KneeRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.KneeRight, JointType.AnkleRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.AnkleRight, JointType.FootRight, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.HipLeft, JointType.KneeLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.KneeLeft, JointType.AnkleLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                    DrawBone(context, brush, JointType.AnkleLeft, JointType.FootLeft, bodies[i].Joints, rect, coordinateMapper, useDepthSpace, line);
                }
            }
        }

        internal static DrawingVisual GetDrawingGroup(this BodyFrame bodyFrame, bool drawBones = true, bool useDepthSpace = true, double pointRadius = 3F, double line = 0.8F)
        {
            var bodyDrawingGroup = new DrawingVisual();

            bodyFrame.CopyToFrameToDrawingGroup(ref bodyDrawingGroup, drawBones, useDepthSpace, pointRadius, line);

            return bodyDrawingGroup;
        }

        internal static void DrawBone(DrawingContext drawingContext, System.Windows.Media.Brush brush, JointType startJoint, JointType endJoint, IReadOnlyDictionary<JointType, Joint> joints, System.Windows.Rect rect, CoordinateMapper coordinateMapper, bool useDepthSpace = true, double line = 0.8F)
        {
            if (joints[startJoint].TrackingState != TrackingState.Tracked
                && joints[endJoint].TrackingState != TrackingState.Tracked)
            {
                return;
            }

            System.Windows.Point startPoint;
            System.Windows.Point endPoint;

            if (useDepthSpace)
            {
                startPoint = coordinateMapper.MapCameraPointToDepthSpace(joints[startJoint].Position).GetPoint();
                endPoint = coordinateMapper.MapCameraPointToDepthSpace(joints[endJoint].Position).GetPoint();
            }
            else
            {
                startPoint = coordinateMapper.MapCameraPointToColorSpace(joints[startJoint].Position).GetPoint();
                endPoint = coordinateMapper.MapCameraPointToColorSpace(joints[endJoint].Position).GetPoint();
            }

            if (rect.Contains(startPoint) && rect.Contains(endPoint))
                drawingContext.DrawLine(new System.Windows.Media.Pen(brush, line), startPoint, endPoint);
        }

        public static BitmapSource ToBitmapSource(this BodyFrame bodyFrame, bool drawBones = true, double pointRadius = 3F, double line = 0.8F)
        {
            var frameDescription = bodyFrame.BodyFrameSource.KinectSensor.DepthFrameSource.FrameDescription;
            var renderTargetBitmap = new RenderTargetBitmap(frameDescription.Width, frameDescription.Height, 96.0, 96.0, PixelFormats.Pbgra32);
            var drawingGroup = bodyFrame.GetDrawingGroup(drawBones, true, pointRadius, line);

            renderTargetBitmap.Render(drawingGroup);

            return renderTargetBitmap;
        }
    }
}