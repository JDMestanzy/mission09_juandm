using Microsoft.AspNetCore.Mvc;
using mission09_juandm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_juandm.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket cartService)
        {
            basket = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
