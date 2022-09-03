using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public class RepositorioPatronesCrecimiento : IRepositorioPatronesCrecimiento
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioPatronesCrecimiento(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<PatronesCrecimiento> GetAllPatronesCrecimientos()
        {
            return _appDbContext.PatronesCrecimientos;
        }

        public PatronesCrecimiento AddPatronesCrecimiento(PatronesCrecimiento patronesCrecimiento)
        {
            var patronAdicionado = _appDbContext.PatronesCrecimientos.Add(patronesCrecimiento);
            _appDbContext.SaveChanges();
            return patronAdicionado.Entity;
        }

        public PatronesCrecimiento GetPatronesCrecimiento(int idPatronesCrecimiento)
        {
            return _appDbContext.PatronesCrecimientos.FirstOrDefault(p => p.Id == idPatronesCrecimiento);
        }

        public PatronesCrecimiento UpdatePatronesCrecimiento(PatronesCrecimiento patronesCrecimiento)
        {
            var patronEncontrado = _appDbContext.PatronesCrecimientos.FirstOrDefault(p => p.Id == patronesCrecimiento.Id);
            if (patronEncontrado!=null)
            {
                patronEncontrado.Valor = patronesCrecimiento.Valor;
                patronEncontrado.FechaHora = patronesCrecimiento.FechaHora;
                patronEncontrado.Descripcion = patronesCrecimiento.Descripcion;
                patronEncontrado.Patron = patronesCrecimiento.Patron;
                _appDbContext.SaveChanges();
            }

            return patronEncontrado;
        }

        public void DeletePatronesCrecimiento(int idPatronesCrecimiento)
        {
            var patronEncontrado = _appDbContext.PatronesCrecimientos.FirstOrDefault(p => p.Id == idPatronesCrecimiento);
            if (patronEncontrado==null)
            {
                return;
            }

            _appDbContext.PatronesCrecimientos.Remove(patronEncontrado);
            _appDbContext.SaveChanges();
        }
    }
}