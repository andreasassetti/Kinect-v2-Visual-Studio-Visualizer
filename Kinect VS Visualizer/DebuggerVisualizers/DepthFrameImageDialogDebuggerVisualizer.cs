﻿using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class DepthFrameImageDialogDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var formatter = new BinaryFormatter();
            var data = formatter.Deserialize(objectProvider.GetData());

            if (data is InternalDepthFrame)
            {
                windowService.ShowDialog(new Kinect2DFrameVisualizerForm(data as InternalDepthFrame, true) { Text = Properties.Resources.DepthFrameImageDialogDebuggerVisualizer });
            }
        }

#if DEBUG

        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(DepthFrameImageDialogDebuggerVisualizer),
                typeof(DepthFrameVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }

#endif

    }
}