using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Entities
{
    public class Address : BaseEntity
    {
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string FullAddress { get; set; }
        public Customer Customer { get; set; }
    }
}
