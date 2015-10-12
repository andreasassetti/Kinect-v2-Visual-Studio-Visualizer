﻿using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    public class HighDefinitionFaceFrameImageDialogDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var formatter = new BinaryFormatter();
            var data = formatter.Deserialize(objectProvider.GetData());

            if (data is InternalHighDefinitionFaceFrame)
            {
                windowService.ShowDialog(new Kinect2DFrameVisualizerForm(data as InternalHighDefinitionFaceFrame) { Text = Properties.Resources.HighDefinitionFaceFrameImageDialogDebuggerVisualizer });
            }
        }

#if DEBUG

        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(HighDefinitionFaceFrameImageDialogDebuggerVisualizer),
                typeof(HighDefinitionFaceFrameVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }

#endif

    }
}