using RelacionamentoPadaria.Data.Entities;
using Microsoft.EntityFrameworkCore;
using RelacionamentoPadaria.Models;

namespace RelacionamentoPadaria.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<FeedbackEntity> Feedbacks { get; set; }
        public DbSet<NpsEntity> Nps { get; set; }
        public DbSet<ContatosModel> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContatosModel>().HasKey(x => x.Id).HasName("PrimaryKey_Id");
            modelBuilder.Entity<UsuarioEntity>().ToTable("Usuarios");
            modelBuilder.Entity<FeedbackEntity>().ToTable("Nps_Feedbacks");
            modelBuilder.Entity<NpsEntity>().ToTable("Notas_Nps");
            modelBuilder.Entity<ContatosModel>().ToTable("Contatos");
        }
    }
}
