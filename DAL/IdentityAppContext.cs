using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawKarTIWypozyczalnia.Models;

namespace PawKarTIWypozyczalnia.DAL
{
    public class IdentityAppContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public IdentityAppContext(DbContextOptions options) : base(options)
        {
        }
    }
}
