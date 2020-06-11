using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoCoHome_Dollo.Models
{
    public class MultipleProducts
    {
        public Product Product { get; set; }

        public List<Product> RelatedProducts { get; set; }

    }
}
