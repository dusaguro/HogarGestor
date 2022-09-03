using System;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;

namespace Consola
{
    class Program
    {
        private static IRepositorioFamiliares _familiares = new RepositorioFamiliares(new AppDbContext());
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            /*var tio = new Familiar
            {
                Nombre = "Camilo",
                Apellido = "Rodríguez",
                Documento = "123456",
                Telefono = "3002556998",
                Correo = "correo@algo.com",
                Genero = Genero.masculino,
                Parentesco = "Tio"
            };
            _familiares.AddFamiliar(tio);*/
            
            /*var tio = new Familiar
            {   
                Id = 1,
                Nombre = "Camilo",
                Apellido = "Nunez",
                Documento = "654987",
                Telefono = "3003334444",
                Correo = "correo@algo.es",
                Genero = Genero.masculino,
                Parentesco = "Papa"
            };
            _familiares.UpdateFamiliar(tio);*/
            
            
            var tio = _familiares.GetFamiliar(1);
            Console.WriteLine("Familiar: " + tio.Nombre + " " + tio.Apellido);
        }
        
    }
}