using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.DebuggerVisualizers;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal class ColorFrameImageDialogDebuggerVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var formatter = new BinaryFormatter();
            var data = formatter.Deserialize(objectProvider.GetData());

            if (data is InternalColorFrame)
            {
                windowService.ShowDialog(new Kinect2DFrameVisualizerForm(data as InternalColorFrame, true) { Text = Properties.Resources.ColorFrameImageDialogDebuggerVisualizer });
            }
        }

#if DEBUG

        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(ColorFrameImageDialogDebuggerVisualizer),
                typeof(ColorFrameVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }

#endif

    }
}