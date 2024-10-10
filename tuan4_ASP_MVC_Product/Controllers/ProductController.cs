using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tuan4_ASP_MVC_Product.Models;

namespace tuan4_ASP_MVC_Product.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Product> dsProduct = context.Products.Include(p => p.Catalog).ToList();
            return View(dsProduct);
        }

    }
}
