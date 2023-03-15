using Microsoft.AspNetCore.Mvc;
using PawKarTIWypozyczalnia.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace PawKarTIWypozyczalnia.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        FilmsContext db;

        public MenuViewComponent(FilmsContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_Menu", db.Kategorie.ToList()));
        }
    }
}
