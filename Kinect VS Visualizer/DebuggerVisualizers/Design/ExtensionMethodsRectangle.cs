using Microsoft.Kinect.Face;

using System.Windows;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsRectangle
    {
        public static Rect ToRect(this RectI rectagnle)
        {
            return new Rect(new Point(rectagnle.Left, rectagnle.Top), new Point(rectagnle.Right, rectagnle.Bottom));
        }
    }
}