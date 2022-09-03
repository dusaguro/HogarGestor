using System.Collections.Generic;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public interface IRepositorioRegistroHistorico
    {
        IEnumerable<RegistroHistorico> GetAllRegistros();
        RegistroHistorico AddRegistro(RegistroHistorico registroHistorico);
        RegistroHistorico GetRegistro(int idRegistro);
        RegistroHistorico UpdateRegistro(RegistroHistorico registroHistorico);
        void DeleteRegistro(int idRegistro);
    }
}