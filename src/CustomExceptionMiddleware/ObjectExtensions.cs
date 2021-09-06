using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace CustomExceptionMiddleware
{
    public static class ObjectExtensions
    {
        public static ExpandoObject ToExpandoObject(this object obj)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj.GetType()))
            {
                expando.Add(property.Name, property.GetValue(obj));
            }

            return (ExpandoObject)expando;
        }
    }
}
