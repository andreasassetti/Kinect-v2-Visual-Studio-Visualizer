using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class Body2DFrameDialogDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var formatter = new BinaryFormatter();
            var data = formatter.Deserialize(objectProvider.GetData());

            if (data is InternalBody2DFrame)
            {
                windowService.ShowDialog(new Kinect2DFrameVisualizerForm(data as InternalBody2DFrame) { Text = Properties.Resources.Body2DFrameDialogDebuggerVisualizer });
            }
        }

#if DEBUG

        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(Body2DFrameDialogDebuggerVisualizer),
                typeof(BodyFrameVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }

#endif

    }
}