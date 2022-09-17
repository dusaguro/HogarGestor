using System;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;

namespace Consola
{
    class Program
    {
        private static IRepositorioFamiliares _familiares = new RepositorioFamiliares(new AppDbContext());

        private static IRepositorioHistoriaClinica _historia = new RepositorioHistoriaClinica(new AppDbContext());
        //private static string fechahoy;
        static void Main(string[] args)
        {
            /*var familiar = new Familiar
            {
                Nombre = "Nathalia",
                Apellido = "Guerrero",
                Documento = "1233569874",
                Telefono = "3017609586",
                Correo = "correo@algo.com",
                Genero = Genero.Femenino,
                Parentesco = "Hermana"
            };
            _familiares.AddFamiliar(familiar);*/
            
            /*var familiar = new Familiar
            {   
                Id = 5,
                Nombre = "Alexandra",
                Apellido = "Guerra",
                Documento = "1233569874",
                Telefono = "3007772020",
                Correo = "algo@correo.es",
                Genero = Genero.Femenino,
                Parentesco = "Prima"
            };
            _familiares.UpdateFamiliar(familiar);*/
            
            /*var familiar = _familiares.GetFamiliar(3);
            Console.WriteLine("Familiar: " + familiar.Nombre + " " + familiar.Apellido);*/
            
            /*_familiares.DeleteFamiliar(3);*/

            var familiar = new Familiar
            {
                //Id = 2,
                Nombre = "Nathalia",
                Apellido = "Guerrero",
                Documento = "1233569874",
                Telefono = "3017609586",
                Correo = "correo@algo.com",
                Genero = Genero.Femenino,
                Parentesco = "Hermana"
            };

            var paciente = new Nino()
            {
                //Id = 7,
                Nombre = "Nathalia",
                Apellido = "Guerrero",
                Documento = "1233569874",
                Telefono = "3017609586",
                Genero = Genero.Femenino,
            };
            
            var medico = new Medico()
            {   
                //Id = 2,
                Nombre = "Nathalia",
                Apellido = "Guerrero",
                Documento = "1233569874",
                Telefono = "3017609586",
                Genero = Genero.Femenino,
            };

            var historia = new HistoriaClinica()
            {
                Diagnostico = "lele pancha",
                idFamiliar = familiar.Id,
                idMedico = medico.Id,
                idNino = paciente.Id
            };
            _historia.AddHistoria(historia);
        }
        
    }
}