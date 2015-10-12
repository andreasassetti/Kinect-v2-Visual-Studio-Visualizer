using Microsoft.Kinect;

using System.Windows;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsFrameDescription
    {
        public static Rect GetRect(this FrameDescription frameDescription)
        {
            return new Rect(0, 0, frameDescription.Width, frameDescription.Height);
        }
    }
}