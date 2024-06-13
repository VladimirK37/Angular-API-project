using Microsoft.EntityFrameworkCore;
using WebTest.Data.Entityes;

namespace WebTest.Data.Context
{
    public class NasosDbContext : DbContext
    {
        public DbSet<NasosEntity> Nasoses { get; set; }
        public DbSet<MotorEntity> Motors { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public NasosDbContext(DbContextOptions<NasosDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NasosEntity>()
                .HasOne(p => p.MotorEntity)
                .WithMany(m => m.Nasoses);

            modelBuilder.Entity<NasosEntity>()
                .HasOne(p => p.MaterialHull)
                .WithMany(m => m.BodyMaterialNasoses);

            modelBuilder.Entity<NasosEntity>()
                .HasOne(p => p.ImpellerMaterial)
                .WithMany(m => m.ImpellerMaterialNasoses);
        }
    }
}
