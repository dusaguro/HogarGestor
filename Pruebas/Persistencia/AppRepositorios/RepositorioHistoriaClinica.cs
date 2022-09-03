using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public class RepositorioHistoriaClinica : IRepositorioHistoriaClinica
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioHistoriaClinica(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<HistoriaClinica> GetAllHistorias()
        {
            return _appDbContext.HistoriasClinicas;
        }

        public HistoriaClinica AddHistoria(HistoriaClinica historiaClinica)
        {
            var historiaAdicionada = _appDbContext.HistoriasClinicas.Add(historiaClinica);
            _appDbContext.SaveChanges();
            return historiaAdicionada.Entity;
        }

        public HistoriaClinica GetHistoria(int idHistoria)
        {
            return _appDbContext.HistoriasClinicas.FirstOrDefault(h => h.Id == idHistoria);
        }

        public HistoriaClinica UpdateHistoria(HistoriaClinica historiaClinica)
        {
            var historiaEncontrada = _appDbContext.HistoriasClinicas.FirstOrDefault(h => h.Id == historiaClinica.Id);
            if (historiaEncontrada!=null)
            {
                historiaEncontrada.Diagnostico = historiaClinica.Diagnostico;
                historiaEncontrada.Medico = historiaClinica.Medico;
                historiaEncontrada.Familiar = historiaClinica.Familiar;
                historiaEncontrada.Nino = historiaClinica.Nino;
                historiaEncontrada.SugerenciasCuidado = historiaClinica.SugerenciasCuidado;
                _appDbContext.SaveChanges();
            }

            return historiaEncontrada;
        }

        public void DeleteHistoria(int idHistoria)
        {
            var historiaEncontrada = _appDbContext.HistoriasClinicas.FirstOrDefault(h => h.Id == idHistoria);
            if (historiaEncontrada==null)
            {
                return;
            }

            _appDbContext.HistoriasClinicas.Remove(historiaEncontrada);
            _appDbContext.SaveChanges();
        }
    }
}