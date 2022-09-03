using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public class RepositorioFamiliares : IRepositorioFamiliares
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioFamiliares(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Familiar> GetAllFamiliares()
        {
            return _appDbContext.Familiares;
        }

        public Familiar AddFamiliar(Familiar familiar)
        {
            var familiarAdicionado = _appDbContext.Familiares.Add(familiar);
            _appDbContext.SaveChanges();
            return familiarAdicionado.Entity;
        }

        public Familiar GetFamiliar(int idFamiliar)
        {
            return _appDbContext.Familiares.FirstOrDefault(f=>f.Id==idFamiliar);
        }

        public Familiar UpdateFamiliar(Familiar familiar)
        {
            var familiarEncontrado = _appDbContext.Familiares.FirstOrDefault(f=>f.Id==familiar.Id);
            if (familiarEncontrado!=null)
            {
                familiarEncontrado.Nombre = familiar.Nombre;
                familiarEncontrado.Apellido = familiar.Apellido;
                familiarEncontrado.Documento = familiar.Documento;
                familiarEncontrado.Telefono = familiar.Telefono;
                familiarEncontrado.Genero = familiar.Genero;
                familiarEncontrado.Parentesco = familiar.Parentesco;
                familiarEncontrado.Correo = familiar.Correo;
                _appDbContext.SaveChanges();
            }
            return familiarEncontrado;
        }

        public void DeleteFamiliar(int idFamiliar)
        {
            var familiarEncontrado = _appDbContext.Familiares.FirstOrDefault(f=>f.Id==idFamiliar);
            if (familiarEncontrado == null)
            {
                return;
            }

            _appDbContext.Familiares.Remove(familiarEncontrado);
            _appDbContext.SaveChanges();
        }
    }
}