
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Models
{
    public class ProductModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public string PriceTitle => Price.ToString("C");

        [Display(Name = "Picture")]
        public IFormFile NewPicture { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}
