using Demo_ASP_MVC_Exo02.Models;

namespace Demo_ASP_MVC_Exo02.Data
{
    public static class FakeDB
    {
        public static class ProductData
        {
            private static List<Product> _Products = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Name = "Demo Produit",
                    Desc = "Ceci est un produit de demo :o",
                    Price = 500m,
                    Discount = null,
                    Reference = "Demo001"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Demo Reduction",
                    Desc = "Ceci est un produit de demo avec une reduction de 50%",
                    Price = 299.99m,
                    Discount = 50,
                    Reference = "Demo002"
                }
            };
            private static int _LastId = 2;

            public static IEnumerable<Product> GetAll()
            {
                return _Products.AsReadOnly();
            }

            public static Product? GetOne(int id)
            {
                return _Products.SingleOrDefault(p => p.Id == id);
            }

            public static void Add(Product product)
            {
                product.Id = ++_LastId;
                _Products.Add(product);
            }

            public static void Delete(int id)
            {
                _Products.RemoveAll(p => p.Id == id);
            }
        }
    }
}
