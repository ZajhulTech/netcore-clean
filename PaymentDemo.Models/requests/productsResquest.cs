using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentDemo.Models.requests
{
    public class productsResquest
    {
        public string Name { get; set; } = string.Empty!;

        public decimal Price { get; set; }

    }
}
