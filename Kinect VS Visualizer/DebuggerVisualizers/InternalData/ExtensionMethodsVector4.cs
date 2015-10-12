using Microsoft.Kinect;

namespace MyFramework.Kinect.VisualStudio.DebuggerVisualizers.InternalData
{
    internal static class ExtensionMethodsVector4
    {
        public static InternalVector4 ToInternalVector4(this Vector4 vector4)
        {
            return new InternalVector4(vector4.W, vector4.X, vector4.Y, vector4.Z);
        }
    }
}
