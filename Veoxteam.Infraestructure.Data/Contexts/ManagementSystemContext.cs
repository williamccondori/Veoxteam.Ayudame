using System.Data.Entity;
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
        //public DbSet<AdjuntoEntity> Adjunto { get; set; }

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
