using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    internal class InternalFrameDescriptionConverter : TypeConverter
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

            TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));
            TypeConverter uintConverter = TypeDescriptor.GetConverter(typeof(uint));
            TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));

            var bytesPerPixel = (uint)uintConverter.ConvertFrom(context, culture, array[0]);
            var diagonalFieldOfView = (float)floatConverter.ConvertFrom(context, culture, array[1]);
            var height = (int)intConverter.ConvertFrom(context, culture, array[2]);
            var horizontalFieldOfView = (float)floatConverter.ConvertFrom(context, culture, array[3]);
            var lengthInPixels = (uint)uintConverter.ConvertFrom(context, culture, array[4]);
            var verticalFieldOfView = (float)floatConverter.ConvertFrom(context, culture, array[5]);
            var width = (int)intConverter.ConvertFrom(context, culture, array[6]);

            return new InternalFrameDescription(
                bytesPerPixel,
                diagonalFieldOfView,
                height,
                horizontalFieldOfView,
                lengthInPixels,
                verticalFieldOfView,
                width);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            object bytesPerPixel = propertyValues["BytesPerPixel"];
            object diagonalFieldOfView = propertyValues["DiagonalFieldOfView"];
            object height = propertyValues["Height"];
            object horizontalFieldOfView = propertyValues["HorizontalFieldOfView"];
            object lengthInPixels = propertyValues["LengthInPixels"];
            object verticalFieldOfView = propertyValues["VerticalFieldOfView"];
            object width = propertyValues["Width"];

            if (bytesPerPixel == null || diagonalFieldOfView == null || height == null || horizontalFieldOfView == null
                || lengthInPixels == null || verticalFieldOfView == null || width == null)
            {
                throw new ArgumentException();
            }

            return new InternalFrameDescription(
                (uint)bytesPerPixel,
                (float)diagonalFieldOfView,
                (int)height,
                (float)horizontalFieldOfView,
                (uint)lengthInPixels,
                (float)verticalFieldOfView,
                (int)width);
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

            var internalFrameDescription = value as InternalFrameDescription;

            if (internalFrameDescription != null)
            {
                if (destinationType == typeof(string))
                {
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + " ";

                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));
                    TypeConverter uintConverter = TypeDescriptor.GetConverter(typeof(uint));
                    TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));

                    var array = new string[7];

                    array[0] = uintConverter.ConvertToString(context, culture, internalFrameDescription.BytesPerPixel);
                    array[1] = floatConverter.ConvertToString(context, culture, internalFrameDescription.DiagonalFieldOfView);
                    array[2] = intConverter.ConvertToString(context, culture, internalFrameDescription.Height);
                    array[3] = floatConverter.ConvertToString(context, culture, internalFrameDescription.HorizontalFieldOfView);
                    array[4] = uintConverter.ConvertToString(context, culture, internalFrameDescription.LengthInPixels);
                    array[5] = floatConverter.ConvertToString(context, culture, internalFrameDescription.VerticalFieldOfView);
                    array[6] = intConverter.ConvertToString(context, culture, internalFrameDescription.Width);

                    return string.Join(separator, array);
                }

                if (destinationType == typeof(InstanceDescriptor))
                {
                    ConstructorInfo constructor =
                        typeof(InternalFrameDescription).GetConstructor(
                            new[]
                                {
                                    typeof(uint), typeof(float), typeof(int), typeof(float), typeof(uint), typeof(float),
                                    typeof(int)
                                });

                    if (constructor != null)
                    {
                        return new InstanceDescriptor(
                            constructor,
                            new object[]
                                {
                                    internalFrameDescription.BytesPerPixel, 
                                    internalFrameDescription.DiagonalFieldOfView,
                                    internalFrameDescription.Height,
                                    internalFrameDescription.HorizontalFieldOfView,
                                    internalFrameDescription.LengthInPixels, 
                                    internalFrameDescription.VerticalFieldOfView,
                                    internalFrameDescription.Width,
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
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(InternalFrameDescription), attributes);

            return properties.Sort(
                    new[]
                        {
                            "BytesPerPixel",
                            "DiagonalFieldOfView",
                            "Height", 
                            "HorizontalFieldOfView",
                            "LengthInPixels",
                            "VerticalFieldOfView",
                            "Width"
                        });
        }
    }
}