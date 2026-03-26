using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Entities;

namespace ToDoList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Passo 1 foi criar as entidades (Models/Entities/Usuario.cs)
        //Passo 2 é criar o DbContext e registrar as entidades nele, passo 3 é criar a migration e depois atualizar o banco de dados
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais, se necessário
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Tarefas)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
