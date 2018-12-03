using Serilog;
using Serilog.Exceptions;
using Serilog.Enrichers.AzureWebApps;

namespace Leadgen.Infrastructure.Logging
{
    public class Setup
    {
        #region Attributes

        /// <summary>
        /// Logging configuration can be set or overriden here.
        /// </summary>
        private SplunkConfig Config;

        #endregion

        #region Constructors

        /// <summary>
        /// Setup Splunk logging using default settings.
        /// </summary>
        public Setup()
        {
            // Get the default configuration if none set
            Config = Config ?? new SplunkConfig();            
        }

        /// <summary>
        /// Setup Splunk logging using custom settings.
        /// </summary>
        /// <param name="config"></param>
        public Setup(SplunkConfig config) : base()
        {
            // Override the default configuration, then call default constructor
            Config = config;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a Splunk logger with specified settings
        /// </summary>
        /// <returns></returns>
        public ILogger Get()
        {
            // Setting our the global application logger
            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.EventCollector(Config.Host, Config.Token, source: Config.Source, sourceType: "json", host: Config.Server, index: Config.Index)                
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        #endregion
    }
}
