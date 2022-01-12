using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Meetups.API.Domain.Entity;

namespace Meetups.API.DAL
{
    public partial class MeetupsContext : DbContext
    {
        public MeetupsContext(DbContextOptions<MeetupsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaEvento> CategoriaEventos { get; set; } = null!;
        public virtual DbSet<Evento> Eventos { get; set; } = null!;
        public virtual DbSet<Participacao> Participacoes { get; set; } = null!;
        public virtual DbSet<StatusEvento> StatusEventos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaEvento>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaEvento);

                entity.ToTable("CategoriaEvento");

                entity.Property(e => e.NomeCategoria)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.ToTable("Evento");

                entity.Property(e => e.DataHoraFim).HasColumnType("datetime");

                entity.Property(e => e.DataHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Local)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdCategoriaEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_CategoriaEvento");

                entity.HasOne(d => d.IdEventoStatusNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdEventoStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_EventoStatus");
            });

            modelBuilder.Entity<Participacao>(entity =>
            {
                entity.HasKey(e => e.IdParticipacao);

                entity.ToTable("Participacao");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LoginParticipante)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Participacoes)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participacao_Evento");
            });

            modelBuilder.Entity<StatusEvento>(entity =>
            {
                entity.HasKey(e => e.IdEventoStatus);

                entity.ToTable("StatusEvento");

                entity.Property(e => e.NomeStatus)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
