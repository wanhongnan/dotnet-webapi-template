using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IntIncludedAttribute : ValidationAttribute
    {
        public int[] Data { get; set; }

        public override bool IsValid(object value)
        {
            if (!(value is int))
                return false;

            return Data.Any(f => f == (int)value);
        }
    }
}
