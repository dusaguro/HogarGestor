using System;
using System.Collections.Generic;
using Dominio.MisFunciones;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.EntityFrameworkCore;

namespace Frontend.Pages.Registros
{
    public class Pacientes : PageModel
    {
        private IRepositorioNino _nino = new RepositorioNino(new AppDbContext());
        private IRepositorioSignosVitales _signo = new RepositorioSignosVitales(new AppDbContext());
        public IEnumerable<Nino> ninos { get; set; }
        public string fechahoy;
        public int select;
        public int mensaje = 0;
        public Nino ninobuscado { get; set; }
        public void OnGet()
        {
            fechahoy = MisFunciones.limitefecha();
            ninos = _nino.GetAllPersonas();
        }

        public void OnPost()
        {
            fechahoy = MisFunciones.limitefecha();

            switch (Request.Form["Registrar"] + Request.Form["Consultar"])
            {
                case "Registrar":
                    var paciente = new Nino();
                    try
                    {
                        paciente.Genero = Request.Form["genere"]=="0"?Genero.Masculino:Genero.Femenino;
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
                            var z = new SignosVitales()
                            {
                                FechaHora = DateTime.Now,
                                FrecCardiada = 0,
                                FrecRespiratoria = 0,
                                Glicemia = 0,
                                Oximetria = 0,
                                PresArterial = 0,
                                Temperatura = 0
                            };
                            z = _signo.AddSignos(z);
                            paciente.idSignosVitales = z.Id;
                            _nino.AddPersona(paciente);
                            mensaje = 3;
                        }
                    }
                    catch (Exception e)
                    {
                        mensaje = 1;
                        Console.WriteLine(e.Message);
                    }
                    
                    break;
                
                case "Consultar":
                    try
                    {
                        ninobuscado = _nino.GetPersona(int.Parse(Request.Form["iden"]));
                        if (ninobuscado==null)
                        {
                            mensaje = 4;
                        }
                    }
                    catch (Exception e)
                    {
                        mensaje = 5;
                        Console.WriteLine(e.Message);
                    }
                    break;
                
                default:
                    //Console.WriteLine("ERROR: Desconocido");
                    break;
            }
            ninos = _nino.GetAllPersonas();
            
            

        }
    }
}