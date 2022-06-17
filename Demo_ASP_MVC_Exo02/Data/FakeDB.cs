using Demo_ASP_MVC_Exo02.Models;

namespace Demo_ASP_MVC_Exo02.Data
{
    public static class FakeDB
    {
        public static class ProductData
        {
            private static List<Product> _Products = new List<Product>();
            private static int _LastId = 0;

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
