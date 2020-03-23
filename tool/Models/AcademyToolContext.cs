using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tool.Models
{
    public partial class AcademyToolContext : DbContext
    {
        public AcademyToolContext()
        {
        }

        public AcademyToolContext(DbContextOptions<AcademyToolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Firma> Firma { get; set; }
        public virtual DbSet<Kurssit> Kurssit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-F5NJUA7\\MSSQLSERVER01;database=AcademyTool;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firma>(entity =>
            {
                entity.Property(e => e.FirmaId).HasColumnName("FirmaID");

                entity.Property(e => e.KurssiId).HasColumnName("KurssiID");

                entity.Property(e => e.Ostaja)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.YhtHenkilö)
                    .HasColumnName("Yht_Henkilö")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kurssit>(entity =>
            {
                entity.HasKey(e => e.KurssiId)
                    .HasName("PK__Kurssit__E3F8AE5267807515");

                entity.Property(e => e.KurssiId).HasColumnName("KurssiID");

                entity.Property(e => e.DlIlmoittautuminen)
                    .HasColumnName("DL_Ilmoittautuminen")
                    .HasColumnType("datetime");

                entity.Property(e => e.DlValmistuminen)
                    .HasColumnName("DL_Valmistuminen")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nimi)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
