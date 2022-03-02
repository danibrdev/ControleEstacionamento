using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TesteBenner.Business.Repository;
using TesteBenner.DAO.Context;
using TesteBenner.DAO.Entities;

namespace TesteBenner.DAO.Repository
{
    public class ParametroRepository : BaseRepository<Parametro>
    {
        public ParametroRepository(EstacionamentoContext context) : base(context) { }

        public Parametro BuscarPorData(DateTime data, bool asNoTracking = false)
        {
            if (data != default(DateTime))
            {
                var query = asNoTracking ? DbSet.AsNoTracking() : DbSet;
                DateTime dataParametro = data.Date;
                return query.Where(d => d.VigenciaInicio <= dataParametro && dataParametro <= d.VigenciaFim).SingleOrDefault();
            }

            return null;
        }
    }
}