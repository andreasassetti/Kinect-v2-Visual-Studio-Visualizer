using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    internal class InternalColorCameraSettingsConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var text = value as string;

            if (string.IsNullOrEmpty(text))
            {
                return base.ConvertFrom(context, culture, value);
            }

            string text2 = text.Trim();

            if (text2.Length == 0)
            {
                return null;
            }
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }

            string[] array = text2.Split(new[] { culture.TextInfo.ListSeparator[0] });

            TypeConverter timeSpanConverter = TypeDescriptor.GetConverter(typeof(TimeSpan));
            TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));

            var exposureTime = (TimeSpan)timeSpanConverter.ConvertFrom(context, culture, array[0]);
            var frameInterval = (TimeSpan)timeSpanConverter.ConvertFrom(context, culture, array[1]);
            var gain = (float)floatConverter.ConvertFrom(context, culture, array[2]);
            var gamma = (float)floatConverter.ConvertFrom(context, culture, array[3]);

            return new InternalColorCameraSettings(
                exposureTime,
                frameInterval,
                gain,
                gamma);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            object exposureTime = propertyValues["ExposureTime"];
            object frameInterval = propertyValues["FrameInterval"];
            object gain = propertyValues["Gain"];
            object gamma = propertyValues["Gamma"];

            if (exposureTime == null || frameInterval == null || gain == null || gamma == null)
            {
                throw new ArgumentException();
            }

            return new InternalColorCameraSettings(
                (TimeSpan)exposureTime,
                (TimeSpan)frameInterval,
                (float)gain,
                (float)gamma);
        }

        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            var internalColorCameraSettings = value as InternalColorCameraSettings;

            if (internalColorCameraSettings != null)
            {
                if (destinationType == typeof(string))
                {
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + " ";

                    TypeConverter timeSpanConverter = TypeDescriptor.GetConverter(typeof(TimeSpan));
                    TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));

                    var array = new string[4];

                    array[0] = timeSpanConverter.ConvertToString(context, culture, internalColorCameraSettings.ExposureTime);
                    array[1] = timeSpanConverter.ConvertToString(context, culture, internalColorCameraSettings.FrameInterval);
                    array[2] = floatConverter.ConvertToString(context, culture, internalColorCameraSettings.Gain);
                    array[3] = floatConverter.ConvertToString(context,culture,internalColorCameraSettings.Gamma);

                    return string.Join(separator, array);
                }

                if (destinationType == typeof(InstanceDescriptor))
                {
                    ConstructorInfo constructor =
                        typeof(InternalColorCameraSettings).GetConstructor(
                            new[]
                                {
                                    typeof(TimeSpan), typeof(TimeSpan), typeof(float), typeof(float)
                                });

                    if (constructor != null)
                    {
                        return new InstanceDescriptor(
                            constructor,
                            new object[]
                                {

                                    internalColorCameraSettings.ExposureTime, 
                                    internalColorCameraSettings.FrameInterval,
                                    internalColorCameraSettings.Gain,
                                    internalColorCameraSettings.Gamma,
                                });
                    }
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(InternalColorCameraSettings), attributes);

            return properties.Sort(
                    new[]
                        {
                            "ExposureTime",
                            "FrameInterval",
                            "Gain",
                            "Gamma"
                        });
        }
    }
}