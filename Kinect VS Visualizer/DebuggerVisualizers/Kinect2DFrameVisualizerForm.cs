using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    internal partial class Kinect2DFrameVisualizerForm : Form
    {
        public Kinect2DFrameVisualizerForm(Internal2DFrame frame, bool showOnlyImage = false)
        {
            InitializeComponent();

            splitContainerFrame.Panel2Collapsed = showOnlyImage;

            propertyGridFrame.SelectedObject = frame;

            var bitmap = new WriteableBitmap(frame.FrameDescription.Width, frame.FrameDescription.Height, 96.0, 96.0, PixelFormats.Bgr32, null);

            bitmap.Lock();
            bitmap.WritePixels(new Int32Rect(0, 0, frame.FrameDescription.Width, frame.FrameDescription.Height), frame.Image, frame.FrameDescription.Width * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8), 0);
            bitmap.Unlock();

            kinect2DFrame1.ImageSource = bitmap;
        }
    }
}