using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HogarGestor.App.Pericistencia
{
    public class RepositorioNino : IRepositorioNino
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioNino(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Nino> GetAllPersonas()
        {
            return _appDbContext.Ninos;
        }

        public Nino AddPersona(Nino persona)
        {
            var ninoAdicionado = _appDbContext.Ninos.Add(persona);
            _appDbContext.SaveChanges();
            return ninoAdicionado.Entity;
        }

        public Nino GetPersona(int idPersona)
        {
            return _appDbContext.Ninos.FirstOrDefault(n => n.Documento == idPersona.ToString());
        }

        public Nino UpdatePersona(Nino persona)
        {
            var ninoEncontrado = _appDbContext.Ninos.FirstOrDefault(n => n.Id == persona.Id);
            if (ninoEncontrado!=null)
            {
                ninoEncontrado.Nombre = persona.Nombre;
                ninoEncontrado.Apellido = persona.Apellido;
                ninoEncontrado.Documento = persona.Documento;
                ninoEncontrado.Telefono = persona.Telefono;
                ninoEncontrado.Genero = persona.Genero;
                ninoEncontrado.Direccion = persona.Direccion;
                ninoEncontrado.Latitud = persona.Latitud;
                ninoEncontrado.Longitud = persona.Longitud;
                ninoEncontrado.Ciudad = persona.Ciudad;
                ninoEncontrado.Nacimiento = persona.Nacimiento;
                ninoEncontrado.PatronesCrecimiento = persona.PatronesCrecimiento;
                _appDbContext.SaveChanges();
            }

            return ninoEncontrado;
        }

        public void DeletePersona(int idPersona)
        {
            var ninoEncontrado = _appDbContext.Ninos.FirstOrDefault(n => n.Documento == idPersona.ToString());
            if (ninoEncontrado==null)
            {
                return;
            }

            _appDbContext.Ninos.Remove(ninoEncontrado);
            _appDbContext.SaveChanges();
        }
        
    }
}