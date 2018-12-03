using Serilog;
using NUnit.Framework;

namespace Leadgen.Infrastructure.Logging.Test
{
    [TestFixture]
    public class LoggingTest
    {
        #region Attributes

        /// <summary>
        /// Class to be used for our current class.
        /// </summary>
        private ILogger _Logger;

        #endregion

        #region Start / End

        [OneTimeSetUp]
        public void Init()
        {
            Log.Logger = new Setup().Get();
            _Logger = Log.ForContext<LoggingTest>();
        }

        [OneTimeTearDown]
        public void End()
        {
            Log.CloseAndFlush();
        }

        #endregion

        #region Basic Tests

        [Test]
        public void VerboseTest()
        {
            _Logger.Verbose("Testing Verbose logging for Infrastructure library.");
        }

        [Test]
        public void DebugTest()
        {            
            _Logger.Fatal("Testing Debug logging for Infrastructure library.");
        }        

        [Test]
        public void InformationTest()
        {
            _Logger.Information("Testing Information logging for Infrastructure library.");
        }

        [Test]
        public void WarningTest()
        {
            _Logger.Warning("Testing Warning logging for Infrastructure library.");
        }

        [Test]
        public void ErrorTest()
        {
            _Logger.Error("Testing Error logging for Infrastructure library.");
        }

        [Test]
        public void FatalTest()
        {
            _Logger.Fatal("Testing Fatal logging for Infrastructure library.");
        }        

        #endregion
    }
}
