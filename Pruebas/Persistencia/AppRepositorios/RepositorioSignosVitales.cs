using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public class RepositorioSignosVitales : IRepositorioSignosVitales
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioSignosVitales(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SignosVitales> GetAllSignos()
        {
            return _appDbContext.SignosVitales;
        }

        public SignosVitales AddSignos(SignosVitales signosVitales)
        {
            var s = _appDbContext.SignosVitales.Add(signosVitales);
            _appDbContext.SaveChanges();
            return s.Entity;
        }

        public SignosVitales GetSignos(int idSignos)
        {
            return _appDbContext.SignosVitales.FirstOrDefault(s => s.Id == idSignos);
        }

        public SignosVitales UpSignos(SignosVitales signosVitales)
        {
            var encontrado = _appDbContext.SignosVitales.FirstOrDefault(s => s.Id == signosVitales.Id);
            if (encontrado!=null)
            {
                encontrado.Id = signosVitales.Id;
                encontrado.FechaHora = signosVitales.FechaHora;
                encontrado.Oximetria = signosVitales.Oximetria;
                encontrado.FrecCardiada = signosVitales.FrecCardiada;
                encontrado.FrecRespiratoria = signosVitales.FrecRespiratoria;
                encontrado.Temperatura = signosVitales.Temperatura;
                encontrado.PresArterial = signosVitales.PresArterial;
                encontrado.Glicemia = signosVitales.Glicemia;
                _appDbContext.SaveChanges();
            }

            return encontrado;
        }

        public void DelSignos(int idSignos)
        {
            var encontrado = _appDbContext.SignosVitales.FirstOrDefault(s => s.Id == idSignos);
            if (encontrado==null)
            {
                return;
            }
            _appDbContext.SignosVitales.Remove(encontrado);
            _appDbContext.SaveChanges();
        }
    }
}