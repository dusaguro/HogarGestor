using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public interface IRepositorioPatronesCrecimiento
    {
        IEnumerable<PatronesCrecimiento> GetAllPatronesCrecimientos();
        PatronesCrecimiento AddPatronesCrecimiento(PatronesCrecimiento patronesCrecimiento);
        PatronesCrecimiento GetPatronesCrecimiento(int idPatronesCrecimiento);
        PatronesCrecimiento UpdatePatronesCrecimiento(PatronesCrecimiento patronesCrecimiento);
        void DeletePatronesCrecimiento(int idPatronesCrecimiento);
    }
}