using System.Data.Entity;

namespace Veoxteam.Infraestructure.Data.Shared
{
    public class BaseContext : DbContext
    {
        public object EntityStatatusHelper { get; private set; }

        public BaseContext()
        {

        }

        public BaseContext(string connectionString = "")
            : base(connectionString)
        {
            //Database.SetInitializer<BaseContext>(null);
        }

        protected void ApplyChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
