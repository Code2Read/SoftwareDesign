namespace Command
{
    using System.Data.Entity;

    public class CommandDbContext : DbContext
    {
        public CommandDbContext()
            : base("name=Almacen")
        {
            Database.SetInitializer<CommandDbContext>(new CreateDatabaseIfNotExists<CommandDbContext>());
        }

        public virtual DbSet<Producto> Productos { get; set; }
    }
}
