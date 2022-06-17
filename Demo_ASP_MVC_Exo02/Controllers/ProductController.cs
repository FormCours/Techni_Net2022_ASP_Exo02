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
            return View(new ProductForm());
        }

        [HttpPost]
        public IActionResult Add(ProductForm productForm)
        {
            if(FakeDB.ProductData.GetAll()
                   .Any(p => p.Reference.ToLower() == productForm.Reference.ToLower()))
            {
                ModelState.AddModelError(
                    nameof(productForm.Reference),
                    "La référence est déjà présente !"
                );
            }

            if(!ModelState.IsValid)
            {
                return View(productForm);
            }

            Product product = new Product
            {
                Name = productForm.Name,
                Desc = productForm.Desc,
                Price = (decimal)productForm.Price,
                Discount = productForm.Discount,
                Reference = productForm.Reference
            };

            FakeDB.ProductData.Add(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete([FromRoute] int id)
        {
            FakeDB.ProductData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
