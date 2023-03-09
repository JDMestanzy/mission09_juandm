using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission09_juandm.Models;
using mission09_juandm.Models.ViewModels;
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
        public IActionResult Index(string bookcategory,int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookcategory || bookcategory == null) 
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        (bookcategory == null 
                        ? repo.Books.Count()
                        : repo.Books.Where(x=> x.Category ==bookcategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
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
