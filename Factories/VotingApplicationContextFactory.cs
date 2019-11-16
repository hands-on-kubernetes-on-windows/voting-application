namespace VotingApplication.Factories
{
    using System;

    using Ninject.Activation;
    using Ninject.Extensions.Logging;

    using VotingApplication.Models;

    public class VotingApplicationContextFactory : IProvider
    {
        private readonly ILogger log;

        public VotingApplicationContextFactory(ILogger log)
        {
            this.log = log;
        }

        public Type Type => typeof(VotingApplicationContext);

        public object Create(IContext context)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING_VotingApplication");
            if (!string.IsNullOrEmpty(connectionString))
            {
                this.log.Info("Using custom connection string provided by environment variable: {0}", connectionString);
                return new VotingApplicationContext(connectionString);
            }

            this.log.Info("Using default connection string");
            return new VotingApplicationContext();
        }
    }
}