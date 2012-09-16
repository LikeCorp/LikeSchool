using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace LikeSchool.Helpers
{
    public static class Serializer
    {
        private static JavaScriptSerializer serializer;
        public static JavaScriptSerializer JavaSerializer
        {
            get
            {
                if (serializer == null)
                    serializer = new JavaScriptSerializer();
                return serializer;
            }
        }
        public static T GetDeserialized<T>(string jsonValue) where T : new()
        {
            return JavaSerializer.Deserialize<T>(jsonValue);
        }

        public static string GetSerialized<T>(T jsonObject) where T : new()
        {
            StringBuilder builder = new StringBuilder();
            JavaSerializer.Serialize(jsonObject,builder);
            return builder.ToString();
        }
    }
}
