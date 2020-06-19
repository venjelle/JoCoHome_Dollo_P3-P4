using JoCoHome_Dollo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoCoHome_Dollo.Models
{
    public class Nieuws
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Inleiding { get; set; }
        public string Schrijver { get; set; }
        public DateTime Datum { get; set; }
        public string Inhoud { get; set; }
        public string Foto { get; set; }

        public void CreateNieuws(ApplicationDbContext _context, string Titel, string Inleiding, string Schrijver, DateTime Datum, string Inhoud, string Foto)
        {
            List<Nieuws> Nieuws = new List<Nieuws>();
            Nieuws Nieuwtje = new Nieuws()
            {
                Titel = Titel,
                Inleiding = Inleiding,
                Schrijver = Schrijver,
                Datum = DateTime.Now,
                Inhoud = Inhoud,
                Foto = Foto
            };
            Nieuws.Add(Nieuwtje);

            _context.AddRange(Nieuws);
            _context.SaveChanges();
        }
    }
}
