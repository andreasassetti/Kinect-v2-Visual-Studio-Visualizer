using System.Windows;

using Microsoft.Kinect;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsPoints
    {
        public static Point ToPoint(this PointF point)
        {
            return new Point(point.X, point.Y);
        }
    }
}