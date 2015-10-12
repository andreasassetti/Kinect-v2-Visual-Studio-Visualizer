using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class LongExposureInfraredFrameImageDialogDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var formatter = new BinaryFormatter();
            var data = formatter.Deserialize(objectProvider.GetData());

            if (data is InternalLongExposureInfraredFrame)
            {
                windowService.ShowDialog(new Kinect2DFrameVisualizerForm(data as InternalLongExposureInfraredFrame) { Text = Properties.Resources.LongExposureInfraredFrameImageDialogDebuggerVisualizer });
            }
        }

#if DEBUG

        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(LongExposureInfraredFrameImageDialogDebuggerVisualizer),
                typeof(LongExposureInfraredFrameVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }

#endif

    }
}