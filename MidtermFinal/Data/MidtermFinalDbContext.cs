using Microsoft.EntityFrameworkCore;
using MidtermFinal.Models;

namespace MidtermFinal.Data
{
    public class MidtermFinalDbContext : DbContext
    {
        public MidtermFinalDbContext(DbContextOptions<MidtermFinalDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<EstablishmentUser> EstablishmentUsers { get; set; }
    }
}
