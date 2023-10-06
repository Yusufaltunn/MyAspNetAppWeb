using System.ComponentModel.DataAnnotations;

namespace MyAspNetAppWeb.ViewModels
{
    public class ProductViewModel
    {
          public int Id { get; set; }
        [Required(ErrorMessage ="isim alanı boş olamaz")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Fiyat alanı boş olamaz")]
        [Range(1, 200, ErrorMessage = "FİYAT alanı 1 ile 1000 arasında değer olmalıdır")]
        public decimal? Price { get; set; }
        
        [Required(ErrorMessage = "Stok alanı boş olamaz")]
        [Range(1,200,ErrorMessage = "Stok alanı 1 ile 200 arasında değer olmalıdır")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "açıklama alanı boş olamaz")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Renk Seçimi boş olamaz")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Yayınlanma tarihi boş olamaz")]
        public DateTime? PublishDate { get; set; }

        public bool IsPublish { get; set; }

        [Required(ErrorMessage = "Yayınlanma Süresi  boş olamaz")]

        public int Expire { get; set; }
    }
}
