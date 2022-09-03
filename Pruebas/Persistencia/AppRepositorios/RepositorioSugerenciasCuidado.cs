using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public class RepositorioSugerenciasCuidado : IRepositorioSugerenciasCuidado
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioSugerenciasCuidado(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SugerenciasCuidado> GetAllSugerencias()
        {
            return _appDbContext.SugerenciasCuidados;
        }

        public SugerenciasCuidado AddSugerencia(SugerenciasCuidado sugerenciasCuidado)
        {
            var sugerenciaAdicionada = _appDbContext.SugerenciasCuidados.Add(sugerenciasCuidado);
            _appDbContext.SaveChanges();
            return sugerenciaAdicionada.Entity;
        }

        public SugerenciasCuidado GetSugerencia(int idSugerencia)
        {
            return _appDbContext.SugerenciasCuidados.FirstOrDefault(s => s.Id == idSugerencia);
        }

        public SugerenciasCuidado UpdateSugerencia(SugerenciasCuidado sugerenciasCuidado)
        {
            var sugerenciaEncontrada = _appDbContext.SugerenciasCuidados.FirstOrDefault(s => s.Id == sugerenciasCuidado.Id);
            if (sugerenciaEncontrada!=null)
            {
                sugerenciaEncontrada.FechaHora = sugerenciasCuidado.FechaHora;
                sugerenciaEncontrada.Descripcion = sugerenciasCuidado.Descripcion;
                _appDbContext.SaveChanges();
            }

            return sugerenciaEncontrada;
        }

        public void DeleteSugerencia(int idSugerencia)
        {
            var sugerenciaEncontrada = _appDbContext.SugerenciasCuidados.FirstOrDefault(s => s.Id == idSugerencia);
            if (sugerenciaEncontrada==null)
            {
                return;
            }

            _appDbContext.SugerenciasCuidados.Remove(sugerenciaEncontrada);
            _appDbContext.SaveChanges();
        }
    }
}