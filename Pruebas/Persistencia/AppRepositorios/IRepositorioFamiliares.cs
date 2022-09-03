using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public interface IRepositorioFamiliares
    {
        IEnumerable<Familiar> GetAllFamiliares();
        Familiar AddFamiliar(Familiar familiar);
        Familiar GetFamiliar(int idFamiliar);
        Familiar UpdateFamiliar(Familiar familiar);
        void DeleteFamiliar(int idFamiliar);
    }
}