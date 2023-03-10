using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_juandm.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Books boo, int qty)
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

        public virtual void RemoveItem(Books bo)
        {
            Items.RemoveAll(x => x.Book.BookId == bo.BookId);
        }
        public virtual void ClearBasket()
        {
            Items.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);
            return sum;
        }

    }

   

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }

    }

}
