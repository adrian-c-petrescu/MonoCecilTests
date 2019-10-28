using System;

namespace TestFody
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CaptureCallAttribute : Attribute
    {
    }
}
