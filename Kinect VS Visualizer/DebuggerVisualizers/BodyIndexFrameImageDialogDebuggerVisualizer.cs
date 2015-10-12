using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class BodyIndexFrameImageDialogDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var formatter = new BinaryFormatter();
            var data = formatter.Deserialize(objectProvider.GetData());

            if (data is InternalBodyIndexFrame)
            {
                windowService.ShowDialog(new Kinect2DFrameVisualizerForm(data as InternalBodyIndexFrame, true) { Text = Properties.Resources.BodyIndexFrameImageDialogDebuggerVisualizer });
            }
        }

#if DEBUG

        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(BodyIndexFrameImageDialogDebuggerVisualizer),
                typeof(BodyIndexFrameVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }

#endif

    }
}