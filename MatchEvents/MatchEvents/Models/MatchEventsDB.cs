namespace MatchEvents.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MatchEventsDB : DbContext
    {
        public MatchEventsDB()
            : base("name=MatchEventsDB")
        {
        }

        public virtual DbSet<Evento> Eventoes { get; set; }
        public virtual DbSet<HistEvento> HistEventoes { get; set; }
        public virtual DbSet<HistMatch> HistMatches { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);
        }
    }
}
