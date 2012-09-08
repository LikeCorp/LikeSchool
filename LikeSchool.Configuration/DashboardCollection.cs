using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LikeSchool.Configuration
{
    public class DashboardCollection : ConfigurationElementCollection
    {
        public MenuElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as MenuElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new MenuElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as MenuElement).DisplayText;
        }
    }
}
