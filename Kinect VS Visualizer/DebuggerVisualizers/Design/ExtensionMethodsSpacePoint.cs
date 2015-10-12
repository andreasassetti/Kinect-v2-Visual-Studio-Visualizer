using System.Windows;

using Microsoft.Kinect;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class ExtensionMethodsSpacePoint
    {
        public static Point GetPoint(this DepthSpacePoint depthSpacePoint)
        {
            return new Point(depthSpacePoint.X, depthSpacePoint.Y);
        }

        public static Point GetPoint(this ColorSpacePoint colorSpacePoint)
        {
            return new Point(colorSpacePoint.X, colorSpacePoint.Y);
        }
    }
}