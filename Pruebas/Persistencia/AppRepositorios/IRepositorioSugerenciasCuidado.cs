using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public interface IRepositorioSugerenciasCuidado
    {
        IEnumerable<SugerenciasCuidado> GetAllSugerencias();
        SugerenciasCuidado AddSugerencia(SugerenciasCuidado sugerenciasCuidado);
        SugerenciasCuidado GetSugerencia(int idSugerencia);
        SugerenciasCuidado UpdateSugerencia(SugerenciasCuidado sugerenciasCuidado);
        void DeleteSugerencia(int idSugerencia);
    }
}