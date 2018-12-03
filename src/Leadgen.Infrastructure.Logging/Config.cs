using System;
using System.Configuration;

namespace Leadgen.Infrastructure.Logging
{
    public class SplunkConfig
    {
        #region Attributes

        /// <summary>
        /// Splunk host where used for logging
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Splunk token for our event collector used for logging.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Splunk index used for logging.
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Splunk token for our event collector used for logging.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Host that will be shown in Splunk logging.
        /// </summary>
        public string Server { get; set; }

        #endregion

        #region Constructors

        public SplunkConfig()
        {
            // Default constructor gets all settings from the the application settings
            Host = ConfigurationManager.AppSettings["splunk:Host"];
            Token = ConfigurationManager.AppSettings["splunk:Token"].ToString();
            Index = ConfigurationManager.AppSettings["splunk:Index"].ToString();
            Source = ConfigurationManager.AppSettings["splunk:Source"].ToString();
            Server = Environment.GetEnvironmentVariable("COMPUTERNAME") ?? string.Empty;
        }

        #endregion
    }
}
