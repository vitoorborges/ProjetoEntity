using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DB
{
    public class ProjetoDb : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Restaurante;Trusted_Connection=true;");
        }
    }
}
