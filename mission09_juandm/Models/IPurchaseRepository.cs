using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_juandm.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Purchases { get; }
        void SavePurchase(Purchase purchase);

        
    }
}
