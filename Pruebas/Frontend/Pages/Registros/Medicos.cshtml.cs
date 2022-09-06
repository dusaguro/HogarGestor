using System;
using System.Collections.Generic;
using Dominio.MisFunciones;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Registros
{
    public class Medicos : PageModel
    {
        private IRepositorioMedicos _medicos = new RepositorioMedicos(new AppDbContext());
        public IEnumerable<Medico> medicos { get; set; }
        public string fechahoy;
        public int mensaje = 0;
        public void OnGet()
        {
            fechahoy = MisFunciones.limitefecha();
            medicos = _medicos.GetAllPersonas();
        }
        
        public void OnPost()
        {   
            fechahoy = MisFunciones.limitefecha();

            var medico = new Medico();
            try
            {
                medico.Genero = Request.Form["genere"]=="0"?Genero.Masculino:Genero.Femenino;
                medico.Nombre = Request.Form["names"];
                medico.Apellido = Request.Form["lastnames"];
                medico.Documento = Request.Form["document"];
                medico.Telefono = Request.Form["phone"];
                medico.Codigo = Request.Form["code"];
                medico.Especialidad = Request.Form["speciality"]=="0"?Especialidad.Pediatra:Especialidad.Nutricionista;
                medico.RegistroRethus = Request.Form["rethus"];
           
                if (medico.Nombre.Equals("")||medico.Apellido.Equals("")||medico.Documento.Equals("")||medico.Telefono.Equals("")||medico.Codigo.Equals("")||medico.RegistroRethus.Equals(""))
                {
                    mensaje = 2;
                }
                else
                {
                    _medicos.AddPersona(medico);
                    mensaje = 3;
                }
            }
            catch (Exception e)
            {
                mensaje = 1;
            }
            
            medicos = _medicos.GetAllPersonas();

        }
    }
}