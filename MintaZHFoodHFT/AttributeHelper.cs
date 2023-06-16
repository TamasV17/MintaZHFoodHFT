using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MintaZHFoodHFT
{
    internal class AttributeHelper
    {

        public string GetPropertyDisplayName<T>(string propertyName)
        {
            var attr = typeof(T)
                .GetProperty(propertyName)
                .GetCustomAttribute<DisplayNameAttribute>();
            if (attr!=null)
            {
                return attr.Value;
            }
            else
            {
                return propertyName;
            }
        }

    }
}
