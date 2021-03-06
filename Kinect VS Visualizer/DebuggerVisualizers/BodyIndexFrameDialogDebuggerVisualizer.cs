﻿using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class BodyIndexFrameDialogDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var formatter = new BinaryFormatter();
            var data = formatter.Deserialize(objectProvider.GetData());

            if (data is InternalBodyIndexFrame)
            {
                windowService.ShowDialog(new Kinect2DFrameVisualizerForm(data as InternalBodyIndexFrame) { Text = Properties.Resources.BodyIndexFrameDialogDebuggerVisualizer });
            }
        }

#if DEBUG
      
        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(BodyIndexFrameDialogDebuggerVisualizer),
                typeof(BodyIndexFrameVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }

#endif

    }
}