using mission09_juandm.Models;
using mission09_juandm.Models.ViewModels;
using System.Linq;

namespace mission09_juandm.Controllers
{
    internal class BookViewModel
    {
        public IQueryable<Books> Books { get; internal set; }
        public PageInfo PageInfo { get; internal set; }
    }
}