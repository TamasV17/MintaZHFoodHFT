using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZHFoodHFT
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class DisplayNameAttribute : Attribute
    {
        public string Value { get; set; }

        public DisplayNameAttribute(string value)
        {
            Value = value;
        }
    }
}
