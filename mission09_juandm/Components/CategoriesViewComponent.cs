using Microsoft.AspNetCore.Mvc;
using mission09_juandm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_juandm.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo {get;set;}
        public CategoriesViewComponent (IBookstoreRepository temp)
        {
            repo = temp;

        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookcategory"];
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
