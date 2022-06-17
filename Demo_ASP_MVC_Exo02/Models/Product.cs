using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_MVC_Exo02.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Nom du produit")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Desc { get; set; }

        [DisplayName("Prix")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [DisplayName("Reduction")]
        public int? Discount { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? DiscountPrice
        {
            get
            {
                return (Discount is null) ? null : (Price - (Price * Discount) / 100m);
            }
        }
        

        [DisplayName("Code barre")]
        public string Reference { get; set; }
    }

    public class ProductForm
    {
        [Required]
        [DisplayName("Nom du produit")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 20)]
        [DisplayName("Description")]
        public string Desc { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DisplayName("Prix de vente")]
        public decimal? Price { get; set; }

        [DisplayName("Reduction")]
        [Range(1, 90)]
        public int? Discount { get; set; }

        [Required]
        [DisplayName("Code barre")]
        public string Reference { get; set; }
    }

}
