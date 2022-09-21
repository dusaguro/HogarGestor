using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public interface IRepositorioSignosVitales
    {
        IEnumerable<SignosVitales> GetAllSignos();
        SignosVitales AddSignos(SignosVitales signosVitales);
        SignosVitales GetSignos(int idSignos);
        SignosVitales UpSignos(SignosVitales signosVitales);
        void DelSignos(int idSignos);
    }
}