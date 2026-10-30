using System;
using System.Collections.Generic;
using System.Text;
using IncreaseMethod;

namespace IncreaseMethod
{
    public static class StringExtensions
    {
        public static bool IsValidBrackets(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }

            while (str.Contains("()") || str.Contains("{}") || str.Contains("[]"))
            {
                str = str.Replace("()", "").Replace("{}", "").Replace("[]", "");
            }

            return str.Length == 0;
        }
    
}
}

