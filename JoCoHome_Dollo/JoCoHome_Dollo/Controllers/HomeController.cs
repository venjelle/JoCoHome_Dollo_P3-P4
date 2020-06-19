using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JoCoHome_Dollo.Models;
using Microsoft.EntityFrameworkCore;
using JoCoHome_Dollo.Data;

namespace JoCoHome_Dollo.Controllers
{
    public class HomeController : Controller
    {
        Nieuws Nieuws = new Nieuws();
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Nieuws> Nieuws = _context.Nieuws.ToList();
            return View(Nieuws);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Nieuwtje()
        {
            List<Nieuws> Nieuws = _context.Nieuws.ToList();
            return View(Nieuws);

        }
    }
}
