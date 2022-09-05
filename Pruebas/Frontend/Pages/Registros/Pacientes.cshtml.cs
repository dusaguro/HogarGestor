using System;
using System.Collections.Generic;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Frontend.Pages.Registros
{
    public class Pacientes : PageModel
    {
        private IRepositorioNino _nino = new RepositorioNino(new AppDbContext());
        public IEnumerable<Nino> ninos { get; set; }
        public string fechahoy;
        public int mensaje = 0;

        public void limitefecha()
        {
            var today = DateTime.Now;
            var dd = today.Day.ToString();
            if (today.Day<10)
            {
                dd = "0" + dd;
            }
            var mm = today.Month.ToString();
            if (today.Month<10)
            {
                mm = "0" + mm;
            }

            var yyyy = today.Year.ToString();
            fechahoy = yyyy + "-" + mm + "-" + dd;
        }
        public void OnGet()
        {
            limitefecha();
            ninos = _nino.GetAllPersonas();
        }

        public void OnPost()
        {   
            limitefecha();

            var paciente = new Nino();
            try
            {
                paciente.Genero = Request.Form["genere"]=="0"?Genero.masculino:Genero.femenino;
                paciente.Nombre = Request.Form["names"];
                paciente.Apellido = Request.Form["lastnames"];
                paciente.Documento = Request.Form["document"];
                paciente.Telefono = Request.Form["phone"];
                paciente.Direccion = Request.Form["address"];
                paciente.Latitud = float.Parse(Request.Form["latitude"]);
                paciente.Longitud = float.Parse(Request.Form["longitude"]);
                paciente.Ciudad = Request.Form["city"];
                paciente.Nacimiento = DateTime.Parse(Request.Form["birthday"]);
                if (paciente.Nombre.Equals("")||paciente.Apellido.Equals("")||paciente.Documento.Equals("")||paciente.Telefono.Equals("")||paciente.Direccion.Equals("")||paciente.Ciudad.Equals(""))
                {
                    mensaje = 2;
                }
                else
                {
                    _nino.AddPersona(paciente);
                    mensaje = 3;
                }
            }
            catch (Exception e)
            {
                mensaje = 1;
            }
            
            ninos = _nino.GetAllPersonas();

        }
    }
}