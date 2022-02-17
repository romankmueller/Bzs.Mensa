using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Bzs.Mensa.Server.Services
{
    /// <summary>
    /// Represents a service base.
    /// </summary>
    public abstract class ServiceBase
    {
        //private readonly DbContextOptionsBuilder<BzsMensaContext> optionsBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        protected ServiceBase(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(@"BzsMensa");
            if (connectionString == null)
            {
                throw new ConfigurationErrorsException("There is no connection string 'BzsMensa' configured.");
            }

            //this.optionsBuilder = new DbContextOptionsBuilder<BzsMensaContext>();
            //this.optionsBuilder.UseSqlServer(connectionString);
        }

        /// <summary>
        /// Creates an entity framework context.
        /// </summary>
        /// <returns>The context.</returns>
        //protected BzsMensaContext CreateContext()
        //{
        //    return new BzsMensaContext(this.optionsBuilder.Options);
        //}
    }
}
