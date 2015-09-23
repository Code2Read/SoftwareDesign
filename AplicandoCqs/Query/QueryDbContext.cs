namespace Query
{
    using System.Data.Entity;

    internal class QueryDbContext : DbContext
    {
        public QueryDbContext()
            : base("name=Almacen")
        {
            Database.SetInitializer<QueryDbContext>(new CreateDatabaseIfNotExists<QueryDbContext>());
        }

        public virtual DbSet<Producto> Productos { get; set; }
    }
}
