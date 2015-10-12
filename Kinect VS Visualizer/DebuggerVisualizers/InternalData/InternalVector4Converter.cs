using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    internal class InternalVector4Converter : TypeConverter
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

            TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));

            var w = (float)floatConverter.ConvertFrom(context, culture, array[0]);
            var x = (float)floatConverter.ConvertFrom(context, culture, array[1]);
            var y = (float)floatConverter.ConvertFrom(context, culture, array[2]);
            var z = (float)floatConverter.ConvertFrom(context, culture, array[3]);


            return new InternalVector4(w, x, y, z);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            object w = propertyValues["W"];
            object x = propertyValues["X"];
            object y = propertyValues["Y"];
            object z = propertyValues["Z"];

            if (x == null || y == null || z == null || w == null)
            {
                throw new ArgumentException();
            }

            return new InternalVector4((float)w, (float)x, (float)y, (float)z);
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

            var internalVector4 = value as InternalVector4;

            if (internalVector4 != null)
            {
                if (destinationType == typeof(string))
                {
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + " ";

                    TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));

                    var array = new[]
                                    {
                                        floatConverter.ConvertToString(context, culture, internalVector4.W),
                                        floatConverter.ConvertToString(context, culture, internalVector4.X),
                                        floatConverter.ConvertToString(context, culture, internalVector4.Y),
                                        floatConverter.ConvertToString(context, culture, internalVector4.Z)
                                    };

                    return string.Join(separator, array);
                }

                if (destinationType == typeof(InstanceDescriptor))
                {
                    ConstructorInfo constructor = typeof(InternalVector4).GetConstructor(new[] { typeof(float), typeof(float), typeof(float), typeof(float) });

                    if (constructor != null)
                    {
                        return new InstanceDescriptor(
                            constructor,
                            new object[]
                                {
                                    internalVector4.W, 
                                    internalVector4.X,
                                    internalVector4.Y,
                                    internalVector4.Z
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
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(InternalVector4), attributes);

            return properties.Sort(
                    new[]
                        {
                            "W",
                            "X",
                            "Y",
                            "Z", 
                        });
        }
    }
}
