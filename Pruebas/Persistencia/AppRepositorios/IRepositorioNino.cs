using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public interface IRepositorioNino
    {
        IEnumerable<Nino> GetAllPersonas();
        Nino AddPersona(Nino persona);
        Nino GetPersona(int idPersona);
        Nino UpdatePersona(Nino persona);
        void DeletePersona(int idPersona);
    }
}