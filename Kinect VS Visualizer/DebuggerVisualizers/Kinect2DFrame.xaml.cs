using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers
{
    /// <summary>
    /// Interaction logic for Kinect2DFrame.xaml
    /// </summary>
    internal partial class Kinect2DFrame : UserControl, INotifyPropertyChanged
    {
        private ImageSource _bitmap;

        public Kinect2DFrame()
        {
            InitializeComponent();

            DataContext = this;
        }

        public ImageSource ImageSource
        {
            get { return _bitmap; }

            set
            {
                _bitmap = value;

                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var tmpPropertyChanged = PropertyChanged;

            if (tmpPropertyChanged != null)
                tmpPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}