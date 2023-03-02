using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_juandm.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Books> Books { get; }

    }
}
