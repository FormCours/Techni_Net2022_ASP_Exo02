namespace Demo_ASP_MVC_Exo02.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string Reference { get; set; }
    }
}
