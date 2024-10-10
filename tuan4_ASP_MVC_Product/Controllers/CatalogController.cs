using Microsoft.AspNetCore.Mvc;
using tuan4_ASP_MVC_Product.Models;


namespace tuan4_ASP_MVC_Product.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Catalog> dsCatalog = context.Catalogs.ToList();
            return View(dsCatalog);
        }

    }
}
