using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoCoHome_Dollo.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Image { get; set; }
        public string Land { get; set; }
        public string Provincie { get; set; }
        public string Plaats { get; set; }
        public string Aantalpersonen { get; set; }
        public string Slaapkamers { get; set; }
        public string Typehuisje { get; set; }
        public string Checkin { get; set; }
        public string Checkout { get; set; }
        public string Omschrijving { get; set; }
    }
}
