using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission09_juandm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_juandm.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;


            var blah = repo.Books
                .OrderBy(p=>p.Title)
                .Skip(pageNum * pageSize)
                .Take(pageSize);
            return View(blah);
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
    }
}
