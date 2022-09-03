using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public class RepositorioMedicos:IRepositorioMedicos
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioMedicos(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Medico> GetAllPersonas()
        {
            return _appDbContext.Medicos;
        }

        public Medico AddPersona(Medico persona)
        {
            var medicoAdicionado = _appDbContext.Medicos.Add(persona);
            _appDbContext.SaveChanges();
            return medicoAdicionado.Entity;
        }

        public Medico GetPersona(int idPersona)
        {
            return _appDbContext.Medicos.FirstOrDefault(m => m.Id == idPersona);
        }

        public Medico UpdatePersona(Medico persona)
        {
            var medicoEncontrado = _appDbContext.Medicos.FirstOrDefault(m => m.Id == persona.Id);
            if (medicoEncontrado!=null)
            {
                medicoEncontrado.Nombre = persona.Nombre;
                medicoEncontrado.Apellido = persona.Apellido;
                medicoEncontrado.Documento = persona.Documento;
                medicoEncontrado.Telefono = persona.Telefono;
                medicoEncontrado.Genero = persona.Genero;
                medicoEncontrado.Codigo = persona.Codigo;
                medicoEncontrado.RegistroRethus = persona.RegistroRethus;
                medicoEncontrado.Especialidad = persona.Especialidad;
                _appDbContext.SaveChanges();
            }
            return medicoEncontrado;
        }

        public void DeletePersona(int idPersona)
        {
            var medicoEncontrado = _appDbContext.Medicos.FirstOrDefault(m => m.Id == idPersona);
            if (medicoEncontrado==null)
            {
                return;
            }
            _appDbContext.Medicos.Remove(medicoEncontrado);
            _appDbContext.SaveChanges();
        }
    }
}