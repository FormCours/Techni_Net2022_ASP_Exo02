using Demo_ASP_MVC_Exo02.Data;
using Demo_ASP_MVC_Exo02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_MVC_Exo02.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Product> products = FakeDB.ProductData.GetAll();
            return View(products);
        }

        public IActionResult Detail([FromRoute] int id)
        {
            Product? product = FakeDB.ProductData.GetOne(id);

            if(product is null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Add()
        //{
        //    return View();
        //}

        public IActionResult Delete([FromRoute] int id)
        {
            FakeDB.ProductData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
