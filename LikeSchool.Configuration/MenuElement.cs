using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LikeSchool.Configuration
{
    public class MenuElement : ConfigurationElement
    {
        [System.Configuration.ConfigurationProperty("id", IsRequired = true)]
        public int Id
        {
            get
            {
                return Convert.ToInt32(this["id"]);
            }
        }
        [System.Configuration.ConfigurationProperty("ishighlevel", IsRequired = true)]
        public bool IsHigherLevel
        {
            get
            {
                return Convert.ToBoolean(this["ishighlevel"]);
            }
        }
        [System.Configuration.ConfigurationProperty("highlevelid", IsRequired = false)]
        public int HighLevelId
        {
            get
            {
                return Convert.ToInt32(this["highlevelid"]);
            }
        }

        [System.Configuration.ConfigurationProperty("image", IsRequired = true)]
        public string ImageUrl
        {
            get
            {
                return this["image"] as string;
            }
        }
        [System.Configuration.ConfigurationProperty("displaytext", IsRequired = true)]
        public string DisplayText
        {
            get
            {
                return this["displaytext"] as string;
            }
        }
        [System.Configuration.ConfigurationProperty("navigateurl", IsRequired = true)]
        public string NavigateUrl
        {
            get
            {
                return this["navigateurl"] as string;
            }
        }
        [System.Configuration.ConfigurationProperty("roletype", IsRequired = true)]
        public string RoleType
        {
            get
            {
                return this["roletype"] as string;
            }
        }
        [System.Configuration.ConfigurationProperty("clientclickevent", IsRequired = true)]
        public string ClientClickEvent
        {
            get
            {
                if (this["clientclickevent"] as string == null)
                {
                    return string.Empty;

                }
                return this["clientclickevent"] as string;
            }
        }
    }
}
