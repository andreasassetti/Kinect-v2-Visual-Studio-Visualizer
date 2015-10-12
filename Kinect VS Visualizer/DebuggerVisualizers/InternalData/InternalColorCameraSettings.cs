using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    [Serializable]
    [TypeConverter(typeof(InternalColorCameraSettingsConverter)), ComVisible(true)]
    internal class InternalColorCameraSettings
    {
        public InternalColorCameraSettings()
        {
            
        }

        public InternalColorCameraSettings(TimeSpan exposureTime, TimeSpan frameInterval, float gain, float gamma)
        {
            ExposureTime = exposureTime;
            FrameInterval = frameInterval;
            Gain = gain;
            Gamma = gamma;
        }

        [ReadOnly(true)]
        public TimeSpan ExposureTime { get; set; }

        [ReadOnly(true)]
        public TimeSpan FrameInterval { get; set; }

        [ReadOnly(true)]
        public float Gain { get; set; }

        [ReadOnly(true)]
        public float Gamma { get; set; }
    }
}