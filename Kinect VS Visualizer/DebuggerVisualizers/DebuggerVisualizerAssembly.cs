using System.Diagnostics;

using Microsoft.Kinect;
using Microsoft.Kinect.Face;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers;

[assembly: DebuggerVisualizer(typeof(ColorFrameDialogDebuggerVisualizer),
                              typeof(ColorFrameVisualizerObjectSource),
                              Target = typeof(ColorFrame), Description = "Kinect ColorFrame 2D visualizer")]

[assembly: DebuggerVisualizer(typeof(ColorFrameImageDialogDebuggerVisualizer),
                              typeof(ColorFrameVisualizerObjectSource),
                              Target = typeof(ColorFrame), Description = "Kinect ColorFrame 2D visualizer, only image")]

[assembly: DebuggerVisualizer(typeof(InfraredFrameDialogDebuggerVisualizer),
                              typeof(InfraredFrameVisualizerObjectSource),
                              Target = typeof(InfraredFrame), Description = "Kinect InfraredFrame 2D visualizer")]

[assembly: DebuggerVisualizer(typeof(InfraredFrameImageDialogDebuggerVisualizer),
                              typeof(InfraredFrameVisualizerObjectSource),
                              Target = typeof(InfraredFrame), Description = "Kinect InfraredFrame 2D visualizer, only image")]

[assembly: DebuggerVisualizer(typeof(LongExposureInfraredFrameDialogDebuggerVisualizer),
                              typeof(LongExposureInfraredFrameVisualizerObjectSource),
                              Target = typeof(LongExposureInfraredFrame), Description = "Kinect LongExposureInfraredFrame 2D visualizer")]

[assembly: DebuggerVisualizer(typeof(LongExposureInfraredFrameImageDialogDebuggerVisualizer),
                              typeof(LongExposureInfraredFrameVisualizerObjectSource),
                              Target = typeof(LongExposureInfraredFrame), Description = "Kinect LongExposureInfraredFrame 2D visualizer, only image")]

[assembly: DebuggerVisualizer(typeof(DepthFrameDialogDebuggerVisualizer),
                              typeof(DepthFrameVisualizerObjectSource),
                              Target = typeof(DepthFrame), Description = "Kinect DepthFrame 2D visualizer")]

[assembly: DebuggerVisualizer(typeof(DepthFrameImageDialogDebuggerVisualizer),
                              typeof(DepthFrameVisualizerObjectSource),
                              Target = typeof(DepthFrame), Description = "Kinect DepthFrame 2D visualizer, only image")]

[assembly: DebuggerVisualizer(typeof(BodyIndexFrameDialogDebuggerVisualizer),
                              typeof(BodyIndexFrameVisualizerObjectSource),
                              Target = typeof(BodyIndexFrame), Description = "Kinect BodyIndexFrame 2D visualizer")]

[assembly: DebuggerVisualizer(typeof(BodyIndexFrameImageDialogDebuggerVisualizer),
                              typeof(BodyIndexFrameVisualizerObjectSource),
                              Target = typeof(BodyIndexFrame), Description = "Kinect BodyIndexFrame 2D visualizer, only image")]

[assembly: DebuggerVisualizer(typeof(Body2DFrameDialogDebuggerVisualizer),
                              typeof(BodyFrameVisualizerObjectSource),
                              Target = typeof(BodyFrame), Description = "Kinect BodyFrame 2D visualizer")]

[assembly: DebuggerVisualizer(typeof(Body2DFrameImageDialogDebuggerVisualizer),
                              typeof(BodyFrameVisualizerObjectSource),
                              Target = typeof(BodyFrame), Description = "Kinect BodyFrame 2D visualizer, only image")]

[assembly: DebuggerVisualizer(typeof(FaceFrameDialogDebuggerVisualizer),
                              typeof(FaceFrameVisualizerObjectSource),
                              Target = typeof(FaceFrame), Description = "Kinect FaceFrame 2D visualizer")]

[assembly: DebuggerVisualizer(typeof(FaceFrameImageDialogDebuggerVisualizer),
                              typeof(FaceFrameVisualizerObjectSource),
                              Target = typeof(FaceFrame), Description = "Kinect FaceFrame 2D visualizer, only image")]

[assembly: DebuggerVisualizer(typeof(HighDefinitionFaceFrameDialogDebuggerVisualizer),
                              typeof(HighDefinitionFaceFrameVisualizerObjectSource),
                              Target = typeof(HighDefinitionFaceFrame), Description = "Kinect HighDefinitionFaceFrame 2D visualizer")]

[assembly: DebuggerVisualizer(typeof(HighDefinitionFaceFrameImageDialogDebuggerVisualizer),
                              typeof(HighDefinitionFaceFrameVisualizerObjectSource),
                              Target = typeof(HighDefinitionFaceFrame), Description = "Kinect HighDefinitionFaceFrame 2D visualizer, only image")]