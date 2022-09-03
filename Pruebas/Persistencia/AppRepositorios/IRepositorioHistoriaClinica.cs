using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public interface IRepositorioHistoriaClinica
    {
        IEnumerable<HistoriaClinica> GetAllHistorias();
        HistoriaClinica AddHistoria(HistoriaClinica historiaClinica);
        HistoriaClinica GetHistoria(int idHistoria);
        HistoriaClinica UpdateHistoria(HistoriaClinica historiaClinica);
        void DeleteHistoria(int idHistoria);
    }
}