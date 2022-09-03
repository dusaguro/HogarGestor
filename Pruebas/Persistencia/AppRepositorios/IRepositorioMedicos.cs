using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public interface IRepositorioMedicos
    {
        IEnumerable<Medico> GetAllPersonas();
        Medico AddPersona(Medico persona);
        Medico GetPersona(int idPersona);
        Medico UpdatePersona(Medico persona);
        void DeletePersona(int idPersona);
    }
}