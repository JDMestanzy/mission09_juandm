using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_juandm.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Books boo, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == boo.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = boo,
                    Quantity = qty
                });

            }
            else
            {
                line.Quantity += qty;
            }
        } 
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);
            return sum;
        }

    }

   

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }

    }

}
