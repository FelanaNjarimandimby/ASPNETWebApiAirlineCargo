using Microsoft.EntityFrameworkCore;
using RéservationApp.Models;

namespace RéservationApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Nature_Marchandise> Nature_Marchandises { get; set; }
        public DbSet<Marchandise> Marchandises { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<LTA> LTAs { get; set; }
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LTA>()
                .HasKey(lt => new { lt.RefReservation, lt.IDTarif });
            modelBuilder.Entity<LTA>()
                .HasOne(re => re.Reservation)
                .WithMany(lt => lt.LTAs)
                .HasForeignKey(re => re.RefReservation);
            modelBuilder.Entity<LTA>()
                .HasOne(tar => tar.Tarif)
                .WithMany(lt => lt.LTAs)
                .HasForeignKey(tar => tar.IDTarif);
        }
    }
}
