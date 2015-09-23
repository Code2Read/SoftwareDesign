namespace Query
{
    using System.Data.Entity;

    public class QueryDbContext : DbContext
    {
        public QueryDbContext()
            : base("name=Almacen")
        {
            Database.SetInitializer<QueryDbContext>(new CreateDatabaseIfNotExists<QueryDbContext>());
        }

        public virtual DbSet<Producto> Productos { get; set; }
    }
}
