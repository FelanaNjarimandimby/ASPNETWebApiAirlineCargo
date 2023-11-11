using Microsoft.EntityFrameworkCore;
using RéservationApp.Models;
using RéservationApp.Models.ModèleLogin;
using System.Data;

namespace RéservationApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<Aeroport> Aeroports { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AvionCargo> AvionCargos { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compagnie> Compagnies { get; set; }
        public DbSet<CoutFret> CoutFrets { get; set; }
        public DbSet<Escale> Escales { get; set; }
        public DbSet<Itineraire> Itineraires { get; set; }
        public DbSet<LTA> LTAs { get; set; }
        public DbSet<Marchandise> Marchandises { get; set; }
        public DbSet<Nature_Marchandise> Nature_Marchandises { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TypeTarif> TypeTarifs { get; set; }        
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<VolCargo> VolCargos { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        //lOGIN
        public DbSet<TblMenu> TblMenu { get; set; }
        public  DbSet<TblPermission> TblPermission { get; set; }
        public DbSet<TblRefreshtoken> TblRefreshtoken { get; set; }
        public DbSet<TblRole> TblRole { get; set; }
        public DbSet<TblUser> TblUser { get; set; }
        public DbSet<Exemple> Exemples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //NEW LOGIN
            
            modelBuilder.Entity<Client>(entity => {
            entity.HasIndex(e => e.ClientMail).IsUnique();
            });

            //A propos du login
            modelBuilder.Entity<TblMenu>(entity =>
            {
                entity.ToTable("tbl_menu");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LinkName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.MenuId });

                entity.ToTable("tbl_permission");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<TblRefreshtoken>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tbl_refreshtoken");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TokenId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.Roleid);

                entity.ToTable("tbl_role");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("tbl_user");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
