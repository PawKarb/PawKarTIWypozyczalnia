using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawKarTIWypozyczalnia.DAL;
using System.Linq;
using System.Threading.Tasks;

namespace PawKarTIWypozyczalnia.ViewComponents
{
    public class CategoryFilmsMenuViewComponent : ViewComponent
    {
        FilmsContext db;

        public CategoryFilmsMenuViewComponent(FilmsContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryName)
        {
            var category = db.Kategorie.Include("Films")
                .Where(c => c.Name.ToLower() == categoryName.ToLower())
                .Single();

            var films = category.Films.ToList();
            return await Task.FromResult((IViewComponentResult)View("_CategoryMenu", films));
        }
    }
}
