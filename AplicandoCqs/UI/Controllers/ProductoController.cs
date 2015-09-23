namespace UI.Controllers
{
    using System.Web.Mvc;
    using Aplicacion;
    using Models;

    public class ProductoController : Controller
    {
        private readonly ProductoServicio servicio = new ProductoServicio();
        
        // GET: Producto
        public ActionResult Index()
        {
            var modelo = servicio.ObtenerProductos();
            return View(modelo);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductoInputModel modelo)
        {
            if (!ModelState.IsValid) return View(modelo);
            
            servicio.AgregarProducto(modelo);
            return RedirectToAction("index");
        }
        
    }
}