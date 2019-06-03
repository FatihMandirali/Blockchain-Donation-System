using Core.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Core.DataBaseContext
{
    public class BitirmeContext : DbContext
    {
        public BitirmeContext()//razor.design
        {

        }

        public BitirmeContext(DbContextOptions<BitirmeContext> options)
            : base(options)
        {

        }
        public DbSet<Yorumlar> Yorumlar { get; set; }
        public DbSet<Personeller> Personeller { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Konular> Konular { get; set; }
        public DbSet<KonuYazarlar> KonuYazarlar { get; set; }
        public DbSet<Makaleler> Makaleler { get; set; }
        public DbSet<Reklamlar> Reklamlar { get; set; }
        public DbSet<Begeniler> Begeniler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Yorumlar>()
            //    .HasRequired<Yorumlar>(x => x.)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
        }
    }
}
