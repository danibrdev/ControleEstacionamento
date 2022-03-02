using Microsoft.EntityFrameworkCore;
using System.Linq;
using TesteBenner.Business.Repository;
using TesteBenner.DAO.Context;
using TesteBenner.DAO.Entities;

namespace TesteBenner.DAO.Repository
{
    public class ControleEstacionamentoRepository : BaseRepository<ControleEstacionamento>
    {
        public ControleEstacionamentoRepository(EstacionamentoContext context) : base(context) { }

        public IQueryable<ControleEstacionamento> BuscarPorPlacaVeiculo(string placaVeiculo, bool asNoTracking = true)
        {
            var query = asNoTracking ? DbSet.AsNoTracking() : DbSet;
            return query.Where(d => d.PlacaVeiculo.Equals(placaVeiculo));
        }

        public ControleEstacionamento BuscarControleAbertoPorPlacaVeiculo(string placaVeiculo, bool asNoTracking = true)
        {
            var query = asNoTracking ? DbSet.AsNoTracking() : DbSet;
            return query.Where(d => d.PlacaVeiculo.Equals(placaVeiculo) && d.Saida == null).FirstOrDefault();
        }
    }
}
