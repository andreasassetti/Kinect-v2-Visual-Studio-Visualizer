using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    internal class InternalRectIConverter : TypeConverter
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

            var bottom = (int)intConverter.ConvertFrom(context, culture, array[0]);
            var left = (int)intConverter.ConvertFrom(context, culture, array[1]);
            var right = (int)intConverter.ConvertFrom(context, culture, array[2]);
            var top = (int)intConverter.ConvertFrom(context, culture, array[3]);

            return new InternalRectI(bottom, left, right, top);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            object bottom = propertyValues["Bottom"];
            object left = propertyValues["Left"];
            object right = propertyValues["Right"];
            object top = propertyValues["Top"];

            if (left == null || right == null || top == null || bottom == null)
            {
                throw new ArgumentException();
            }

            return new InternalRectI((int)bottom, (int)left, (int)right, (int)top);
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

            var internalRectI = value as InternalRectI;

            if (internalRectI != null)
            {
                if (destinationType == typeof(string))
                {
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + " ";

                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));

                    var array = new[]
                                    {
                                        intConverter.ConvertToString(context, culture, internalRectI.Bottom),
                                        intConverter.ConvertToString(context, culture, internalRectI.Left),
                                        intConverter.ConvertToString(context, culture, internalRectI.Right),
                                        intConverter.ConvertToString(context, culture, internalRectI.Top)
                                    };

                    return string.Join(separator, array);
                }

                if (destinationType == typeof(InstanceDescriptor))
                {
                    ConstructorInfo constructor = typeof(InternalRectI).GetConstructor(new[] { typeof(float), typeof(float), typeof(float), typeof(float) });

                    if (constructor != null)
                    {
                        return new InstanceDescriptor(
                            constructor,
                            new object[]
                                {
                                    internalRectI.Bottom,
                                    internalRectI.Left,
                                    internalRectI.Right,
                                    internalRectI.Top
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
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(InternalRectI), attributes);

            return properties.Sort(
                    new[]{
                            "Bottom",
                            "Left",
                            "Right",
                            "Top",
                        });
        }
    }
}
