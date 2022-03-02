using Microsoft.EntityFrameworkCore;
using TesteBenner.DAO.Entities;
using TesteBenner.DAO.Mapping;

namespace TesteBenner.DAO.Context
{
    public class EstacionamentoContext : DbContext
    {
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<ControleEstacionamento> ControlesEstacionamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new ParametroMap());
            modelBuilder.ApplyConfiguration(new ControleEstacionamentoMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"User ID=mizvfvirkzlluu; Password=1bdd0837517333c81305527a3f78a63fa493f3b9f196234efa2778fb442527bc; Host=ec2-44-194-112-166.compute-1.amazonaws.com; Port=5432; Database=dbls0as3i1rg4r; Pooling=true; sslmode=Require; Trust Server Certificate=true; ");
        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
