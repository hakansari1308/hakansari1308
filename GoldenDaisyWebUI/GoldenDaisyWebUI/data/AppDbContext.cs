using GoldenDaisyWebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldenDaisyWebUI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
        
    }
        public DbSet<RandevuModel> Randevu { get; set; }
        public DbSet<DuyuruModel> Duyuru { get; set; }
        public DbSet<KullaniciModel>musteri { get; set; }
    }

        
}
