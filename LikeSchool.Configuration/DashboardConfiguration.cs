using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LikeSchool.Configuration
{
    public class DashboardConfiguration : ConfigurationSection
    {
        private static string sConfigurationSectionConst = "MenuConfiguration";

        /// <summary>
        /// Returns an shiConfiguration instance
        /// </summary>
        public static DashboardConfiguration GetConfig()
        {

            return (DashboardConfiguration)System.Configuration.ConfigurationManager.
               GetSection(DashboardConfiguration.sConfigurationSectionConst) ??
               new DashboardConfiguration();

        }
        [System.Configuration.ConfigurationProperty("dashboard")]
        public DashboardCollection DashboardCollection
        {
            get
            {
                return (DashboardCollection)this["dashboard"] ??
                   new DashboardCollection();
            }
        }
    }
}
