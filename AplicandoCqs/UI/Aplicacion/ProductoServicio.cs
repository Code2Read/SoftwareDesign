namespace UI.Aplicacion
{
    using System.Linq;
    using Command;
    using Models;
    using Query;

    public class ProductoServicio
    {
        public void AgregarProducto(ProductoInputModel productoModel)
        {
            using (var db = new CommandDbContext())
            {
                db.Productos.Add(new Command.Producto
                {
                    Nombre = productoModel.Nombre,
                    CategoriaNombre = productoModel.Categoria,
                    TipoNombre = productoModel.Tipo
                });
                db.SaveChanges();
            }
        }

        public ProductoViewModel ObtenerProductos()
        {
            var modelo = new ProductoViewModel();
            using (var db = new QueryDatabase())
            {
                var lista = db.Productos.ToList();
                modelo.Productos = lista;
            }

            return modelo;
        } 
    }
}