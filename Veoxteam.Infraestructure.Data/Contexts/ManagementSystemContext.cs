using System.Data.Entity;
using Veoxteam.Domain.Entities;
using Veoxteam.Infraestructure.Data.Shared;

namespace Veoxteam.Infraestructure.Data.Contexts
{
    public class ManagementSystemContext : BaseContext
    {
        public ManagementSystemContext()
       : base("name=ManagementSystemConnection")
        {
            //Database.SetInitializer<BotContext>(null);
        }

        public DbSet<ReportTypeEntity> ReportType { get; set; }
        public DbSet<ReportEntity> Report { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //aoModelbuilder.Configurations.Add(new AdjuntoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public void ApplyAllChanges()
        {
            base.ApplyChanges();
        }
    }
}
