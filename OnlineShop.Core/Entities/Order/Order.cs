using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
