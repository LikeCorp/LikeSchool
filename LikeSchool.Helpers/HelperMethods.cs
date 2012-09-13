using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Helpers
{
    public static class HelperMethods
    {
        public static string GetSubString(string firstIndexString, string lastIndexString, string originalValue)
        {
            int startIndex = originalValue.LastIndexOf(firstIndexString) + 1;
            int lastIndex = originalValue.LastIndexOf(lastIndexString);
            return originalValue.Substring(startIndex, lastIndex - startIndex);
        }
        public static string ToUpperCaseFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            char[] strArray = str.ToCharArray();
            strArray[0] = char.ToUpper(strArray[0]);
            return new string(strArray);
        }
    }
}
