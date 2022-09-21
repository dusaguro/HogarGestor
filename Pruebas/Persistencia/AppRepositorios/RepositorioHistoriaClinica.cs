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

        public HistoriaClinica GetHistoriaNino(int idNino)
        {
            return _appDbContext.HistoriasClinicas.FirstOrDefault(h => h.idNino == idNino);
        }

        public IEnumerable<HistoriaClinica> GetHistoriaFamiliar(int idFamiliar)
        {
            return _appDbContext.HistoriasClinicas.Where(h => h.idFamiliar == idFamiliar).ToList();
        }

        public IEnumerable<HistoriaClinica> GetHistoriaMedico(int idMedico)
        {
            return _appDbContext.HistoriasClinicas.Where(h => h.idMedico == idMedico).ToList();
        }

        public HistoriaClinica UpdateHistoria(HistoriaClinica historiaClinica)
        {
            var historiaEncontrada = _appDbContext.HistoriasClinicas.FirstOrDefault(h => h.Id == historiaClinica.Id);
            if (historiaEncontrada!=null)
            {
                historiaEncontrada.Diagnostico = historiaClinica.Diagnostico;
                historiaEncontrada.idMedico = historiaClinica.idMedico;
                historiaEncontrada.idFamiliar = historiaClinica.idFamiliar;
                historiaEncontrada.idNino = historiaClinica.idNino;
                historiaEncontrada.idSugerenciasCuidado = historiaClinica.idSugerenciasCuidado;
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