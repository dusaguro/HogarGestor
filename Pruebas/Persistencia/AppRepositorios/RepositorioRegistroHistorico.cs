using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public class RepositorioRegistroHistorico : IRepositorioRegistroHistorico
    {
        private readonly AppDbContext _appDbContext;

        public RepositorioRegistroHistorico(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<RegistroHistorico> GetAllRegistros()
        {
            return _appDbContext.RegistrosHistoricos;
        }

        public RegistroHistorico AddRegistro(RegistroHistorico registroHistorico)
        {
            var registroAdicionado = _appDbContext.RegistrosHistoricos.Add(registroHistorico);
            _appDbContext.SaveChanges();
            return registroAdicionado.Entity;
        }

        public RegistroHistorico GetRegistro(int idRegistro)
        {
            return _appDbContext.RegistrosHistoricos.FirstOrDefault(r => r.Id == idRegistro);
        }

        public RegistroHistorico UpdateRegistro(RegistroHistorico registroHistorico)
        {
            var registroEncontrado = _appDbContext.RegistrosHistoricos.FirstOrDefault(r => r.Id == registroHistorico.Id);
            if (registroEncontrado!=null)
            {
                registroEncontrado.idPatronesCrecimiento = registroHistorico.idPatronesCrecimiento;
                _appDbContext.SaveChanges();
            }

            return registroEncontrado;
        }

        public void DeleteRegistro(int idRegistro)
        {
            throw new System.NotImplementedException();
        }
    }
}