using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoCoHome_Dollo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JoCoHome_Dollo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Home/Index")]

    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        RoleManager<IdentityRole> _roleManager;

        public HomeController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;


        }

        [Area("Admin")]

        [Authorize(Roles = "Admin")]



        public IActionResult Index()
        {


            return View();
        }
    }
}