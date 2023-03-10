﻿using Microsoft.AspNetCore.Mvc;
using mission09_juandm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_juandm.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }
        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]   
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if(basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Items.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }

        }
    }
}
