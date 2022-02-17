using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Bzs.Mensa.Server.DataAccess.Models;

namespace Bzs.Mensa.Server.DataAccess.Context
{
    public partial class BzsMensaContext : DbContext
    {
        public BzsMensaContext()
        {
        }

        public BzsMensaContext(DbContextOptions<BzsMensaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergie> Allergies { get; set; } = null!;
        public virtual DbSet<Benutzer> Benutzers { get; set; } = null!;
        public virtual DbSet<BenutzerAllergie> BenutzerAllergies { get; set; } = null!;
        public virtual DbSet<Essen> Essens { get; set; } = null!;
        public virtual DbSet<Klasse> Klasses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RM-2017-06\\SQLEXPRESS2016;Database=BzsMensa;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergie>(entity =>
            {
                entity.ToTable("Allergie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung).HasMaxLength(50);
            });

            modelBuilder.Entity<Benutzer>(entity =>
            {
                entity.ToTable("Benutzer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BenutzerName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.HasOne(d => d.Klasse)
                    .WithMany(p => p.Benutzers)
                    .HasForeignKey(d => d.KlasseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Benutzer.KlasseId_Klasse.Id");
            });

            modelBuilder.Entity<BenutzerAllergie>(entity =>
            {
                entity.ToTable("BenutzerAllergie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Allergie)
                    .WithMany(p => p.BenutzerAllergies)
                    .HasForeignKey(d => d.AllergieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BenutzerAllergie.AllergieId_Allergie.Id");

                entity.HasOne(d => d.Benutzer)
                    .WithMany(p => p.BenutzerAllergies)
                    .HasForeignKey(d => d.BenutzerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BenutzerAllergie.BenutzerId_Benutzer.Id");
            });

            modelBuilder.Entity<Essen>(entity =>
            {
                entity.ToTable("Essen");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.HasOne(d => d.Benutzer)
                    .WithMany(p => p.Essens)
                    .HasForeignKey(d => d.BenutzerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Essen.BenutzerId_Benutzer.Id");
            });

            modelBuilder.Entity<Klasse>(entity =>
            {
                entity.ToTable("Klasse");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung).HasMaxLength(10);

                entity.Property(e => e.Schicht1).HasColumnName("Schicht_1");

                entity.Property(e => e.Schicht2).HasColumnName("Schicht_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
