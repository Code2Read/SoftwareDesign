namespace Query
{
    using System;
    using System.Linq;

    public class QueryDatabase : IDisposable
    {
        private readonly QueryDbContext context = new QueryDbContext();

        public IQueryable<Producto> Productos
        {
            get
            {
                return context.Productos;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
