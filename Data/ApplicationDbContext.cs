using Microsoft.EntityFrameworkCore;
using WorldCups.Models;

namespace WorldCups.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Categories> categories {  get; set; }
        public DbSet<CategoriesTransportation> transportations { get; set; }
        public DbSet<Stadiums> stadiums { get; set; }
        public DbSet<TableFootball> tableFootballs { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Transport> transport { get; set; }


    }
}
