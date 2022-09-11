using System;
using System.Collections.Generic;
using Dominio.MisFunciones;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Registros
{
    public class Familiares : PageModel
    {
        private static IRepositorioFamiliares _familiares = new RepositorioFamiliares(new AppDbContext());
        public IEnumerable<Familiar> familiares { get; set; }
        public string fechahoy;
        public int mensaje;
        public void OnGet()
        {
            fechahoy = MisFunciones.limitefecha();
            familiares = _familiares.GetAllFamiliares();
        }

        public void OnPost()
        {
            fechahoy = MisFunciones.limitefecha();
            
            var familiar = new Familiar();
            try
            {
                familiar.Genero = Request.Form["genere"]=="0"?Genero.Masculino:Genero.Femenino;
                familiar.Nombre = Request.Form["names"];
                familiar.Apellido = Request.Form["lastnames"];
                familiar.Documento = Request.Form["document"];
                familiar.Telefono = Request.Form["phone"];
                familiar.Parentesco = Request.Form["relationship"];
                familiar.Correo = Request.Form["e-mail"];
                
                if (familiar.Nombre.Equals("")||familiar.Apellido.Equals("")||familiar.Documento.Equals("")||familiar.Telefono.Equals("")||familiar.Parentesco.Equals("")||familiar.Correo.Equals(""))
                {
                    mensaje = 2;
                }
                else
                {
                    _familiares.AddFamiliar(familiar);
                    mensaje = 3;
                }
            }
            catch (Exception e)
            {
                mensaje = 1;
                Console.WriteLine(e.Message);
            }
            
            familiares = _familiares.GetAllFamiliares();
        }
    }
}