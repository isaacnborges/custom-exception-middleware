using System;

namespace CustomExceptionMiddleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IgnoreCustomExceptionAttribute : Attribute
    { }
}
