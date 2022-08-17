using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bzs.Mensa.Server.UnitTest
{
    /// <summary>
    /// Represents the assembly unit test.
    /// </summary>
    [TestClass]
    public sealed class AssemblyUnitTest
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        /// <summary>
        /// Initializes the test assembly.
        /// </summary>
        /// <param name="context">The test context.</param>
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
        }

        /// <summary>
        /// Tests the log4net configuration.
        /// </summary>
        [TestMethod]
        public void Log4NetConfigured()
        {
            Log.Info("log4net configured.");
        }
    }
}
