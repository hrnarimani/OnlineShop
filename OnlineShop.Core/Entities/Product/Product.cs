using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public ICollection<Category> Categories { get; set; }
        
    }
}
