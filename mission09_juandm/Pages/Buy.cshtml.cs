using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission09_juandm.Infrastructure;
using mission09_juandm.Models;

namespace mission09_juandm.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        
        public Basket basket { get; set; }
        public BuyModel(IBookstoreRepository temp, Basket b)
        { 
            repo = temp;
            basket = b;
        }


        
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl) 
        {
            ReturnUrl = returnUrl ?? "/";
            
        }
        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            basket.AddItem(b, 1);

            
            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl});

        }
    }
}
