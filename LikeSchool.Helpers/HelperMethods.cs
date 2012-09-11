using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeSchool.Helpers
{
    public static class HelperMethods
    {
        public static string GetSubString(string firstIndexString, string lastIndexString,string originalValue)
        {
            int startIndex = originalValue.LastIndexOf(firstIndexString)+1;
            int lastIndex = originalValue.LastIndexOf(lastIndexString);
            return originalValue.Substring(startIndex, lastIndex-startIndex);
        }
    }
}
