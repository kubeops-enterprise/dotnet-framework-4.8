using SimpleNetFrame.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleNetFrame.Context
{
    public class KubeExContext : DbContext
    {
        public KubeExContext() : base("KubeExContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<RoutineReport> RoutineReports { get; set; }
    }
}