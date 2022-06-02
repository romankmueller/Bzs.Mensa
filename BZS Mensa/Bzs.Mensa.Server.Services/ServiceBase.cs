using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using Bzs.Mensa.Server.DataAccess.Context;
using Bzs.Mensa.Server.DataAccess.Models;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a service base.
    /// </summary>
    public abstract class ServiceBase
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly DbContextOptionsBuilder<BzsMensaContext> optionsBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        protected ServiceBase(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(@"BzsMensa");
            if (connectionString == null)
            {
                throw new ConfigurationErrorsException(@"There is no connection string 'BzsMensa' configured.");
            }

            this.optionsBuilder = new DbContextOptionsBuilder<BzsMensaContext>();
            this.optionsBuilder.UseSqlServer(connectionString);
        }

        /// <summary>
        /// Creates an entity framework context.
        /// </summary>
        /// <returns>The context.</returns>
        protected BzsMensaContext CreateContext()
        {
            return new BzsMensaContext(this.optionsBuilder.Options);
        }

        /// <summary>
        /// Gets a value indicating whether the database is alive.
        /// </summary>
        public bool IsDatabaseAlive
        {
            get
            {
                try
                {
                    using (BzsMensaContext ctx = this.CreateContext())
                    {
                        List<Benutzer> data = ctx.Benutzers.ToList();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Debug.Write(e);
                }

                return false;
            }
        }

        /// <summary>
        /// Writes an info log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void LogInfo(object message)
        {
            Log.Info(message);
        }

        /// <summary>
        /// Writes an info log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        protected void LogInfo(object message, Exception exception)
        {
            Log.Info(message, exception);
        }

        /// <summary>
        /// Writes a debug log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void LogDebug(object message)
        {
            Log.Debug(message);
        }

        /// <summary>
        /// Writes a debug log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        protected void LogDebug(object message, Exception exception)
        {
            Log.Debug(message, exception);
        }

        /// <summary>
        /// Writes an warning log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void LogWarn(object message)
        {
            Log.Warn(message);
        }

        /// <summary>
        /// Writes an warn log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        protected void LogWarn(object message, Exception exception)
        {
            Log.Warn(message, exception);
        }

        /// <summary>
        /// Writes an error log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void LogError(object message)
        {
            Log.Error(message);
        }

        /// <summary>
        /// Writes an error log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        protected void LogError(object message, Exception exception)
        {
            Log.Error(message, exception);
        }

        /// <summary>
        /// Writes a fatal log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void LogFatal(object message)
        {
            Log.Fatal(message);
        }

        /// <summary>
        /// Writes a fatal log entry.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        protected void LogFatal(object message, Exception exception)
        {
            Log.Fatal(message, exception);
        }
    }
}
