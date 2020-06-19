using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoCoHome_Dollo.Models
{
    public class MultipleNieuws
    {
        public Nieuws Nieuws { get; set; }

        public List<Nieuws> RelatedNieuws { get; set; }
    }
}
