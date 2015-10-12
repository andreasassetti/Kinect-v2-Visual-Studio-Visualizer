using System;
using System.Windows.Media;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.Design
{
    public static class BodyIndexColor
    {
        public static Color Body0 = Colors.Red;
        public static Color Body1 = Colors.Yellow;
        public static Color Body2 = Colors.Green;
        public static Color Body3 = Colors.Cyan;
        public static Color Body4 = Colors.Blue;
        public static Color Body5 = Colors.Magenta;

        public static Color Background = Colors.Transparent;

        public static Brush GetBrushFromBodyIndex(int bodyIndex)
        {
            return GetBrushFromBodyIndex(Convert.ToByte(bodyIndex));
        }

        public static Brush GetBrushFromBodyIndex(byte bodyIndex)
        {
            return new SolidColorBrush(GetColorFromBodyIndex(bodyIndex));
        }

        public static Color GetColorFromBodyIndex(byte bodyIndex)
        {
            switch (bodyIndex)
            {
                case 0:
                {
                    return Body0;
                }
      
                case 1:
                {
                    return Body1;
                }

                case 2:
                {
                    return Body2;
                }

                case 3:
                {
                    return Body3;
                }

                case 4:
                {
                    return Body4;
                }

                case 5:
                {
                    return Body5;
                }

                default:
                {
                    return Background;
                }
            }
        }

        public static Color[] GetBodyIndexColorArray()
        {
            return new[]
            {
                Body0,
                Body1,
                Body2,
                Body3,
                Body4,
                Body5
            };
        }
    }
}