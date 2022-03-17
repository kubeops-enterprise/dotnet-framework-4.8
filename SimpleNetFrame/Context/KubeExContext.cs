using Npgsql;
using SimpleNetFrame.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleNetFrame.Context
{
    [DbConfigurationType(typeof(RoutineReportConfiguration))]
    public class KubeExContext : DbContext
    {
        public KubeExContext() : base("kubeexuser") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            modelBuilder.HasDefaultSchema("");
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<RoutineReport> RoutineReports { get; set; }
    }

    public class RoutineReportConfiguration : DbConfiguration
    {
        public RoutineReportConfiguration()
        {
            var name = "Npgsql";

            SetProviderFactory(providerInvariantName: name,
                               providerFactory: NpgsqlFactory.Instance);

            SetProviderServices(providerInvariantName: name,
                                provider: NpgsqlServices.Instance);

            SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
        }
    }
}