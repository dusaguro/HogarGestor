using System;
using System.Collections.Generic;
using Dominio.MisFunciones;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Registros
{
    public class Editar : PageModel
    {
        private readonly IRepositorioNino _nino = new RepositorioNino(new AppDbContext());
        private readonly IRepositorioMedicos _medico = new RepositorioMedicos(new AppDbContext());
        private readonly IRepositorioFamiliares _familiar = new RepositorioFamiliares(new AppDbContext());
        private readonly IRepositorioHistoriaClinica _historia = new RepositorioHistoriaClinica(new AppDbContext());
        public string fechahoy;
        public int mensaje;
        public Nino nino { get; set; }
        public Medico medico { get; set; }
        public Familiar familiar { get; set; }
        public HistoriaClinica historia { get; set; }
        public IEnumerable<Nino> ninos { get; set; }
        public IEnumerable<Familiar> familiares { get; set; }
        public IEnumerable<Medico> medicos { get; set; }
        public IActionResult OnGet(int id,string tipo)
        {
            fechahoy = MisFunciones.limitefecha();
            switch (tipo)
            {
                case "nino":
                    nino = _nino.GetPersona(id);
                    if (nino==null)
                    {
                        return RedirectToPage("../Error");
                    }
                    return Page();
                
                case "medico":
                    medico = _medico.GetPersona(id);
                    if (medico==null)
                    {
                        return RedirectToPage("../Error");
                    }
                    return Page();
                
                case "familiar":
                    familiar = _familiar.GetFamiliar(id);
                    if (familiar==null)
                    {
                        return RedirectToPage("../Error");
                    }
                    return Page();
                
                case "asignacion":
                    historia = _historia.GetHistoria(id);
                    ninos = _nino.GetAllPersonas();
                    familiares = _familiar.GetAllFamiliares();
                    medicos = _medico.GetAllPersonas();
                    if (historia==null)
                    {
                        return RedirectToPage("../Error");
                    }
                    return Page();
                
                default:
                    return RedirectToPage("../Error");
                
            }
        }

        public IActionResult OnPost(int id, string tipo)
        {
            fechahoy = MisFunciones.limitefecha();
            
            switch (tipo)
            {
                case "nino":
                    try
                    {
                        var paciente = new Nino();
                        paciente.Id = int.Parse(Request.Form["cc"]);
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
                            nino = _nino.UpdatePersona(paciente);
                            mensaje = 3;
                            return RedirectToPage("./Pacientes");
                    
                        }
                    }
                    catch (Exception e)
                    {
                        mensaje = 1;
                        Console.WriteLine(e.Message);
                
                    }
                    nino = _nino.GetPersona(id);
                    if (nino==null)
                    {
                        return RedirectToPage("../Error");
                    }
                    return Page();
                
                case "medico":
                    
                    try
                    {
                        var medico = new Medico();
                        medico.Id = int.Parse(Request.Form["cc"]);
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
                            this.medico = _medico.UpdatePersona(medico);
                            mensaje = 3;
                            return RedirectToPage("./Medicos");
                        }
                    }
                    catch (Exception e)
                    {
                        mensaje = 1;
                        Console.WriteLine(e.Message);
                    }
                    medico = _medico.GetPersona(id);
                    if (medico==null)
                    {
                        return RedirectToPage("../Error");
                    }
                    return Page();
                
                case "familiar":
                    
                    try
                    {
                        var familiar = new Familiar();
                        familiar.Id = int.Parse(Request.Form["cc"]);
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
                            this.familiar = _familiar.UpdateFamiliar(familiar);
                            mensaje = 3;
                            return RedirectToPage("./Familiares");
                        }
                    }
                    catch (Exception e)
                    {
                        mensaje = 1;
                        Console.WriteLine(e.Message);
                    }
                    familiar = _familiar.GetFamiliar(id);
                    if (familiar==null)
                    {
                        return RedirectToPage("../Error");
                    }
                    return Page();
                
                case "asignacion":
                    try
                    {
                        var history = new HistoriaClinica();
                        history.Id = int.Parse(Request.Form["cc"]);
                        history.idNino = int.Parse(Request.Form["paciente"]);
                        history.idFamiliar = int.Parse(Request.Form["familiar"]);
                        history.idMedico = int.Parse(Request.Form["medico"]);
                        history.Diagnostico = Request.Form["diagnostico"];
                        if (history.idNino==0||history.idFamiliar==0||history.idMedico==0)
                        {
                            mensaje = 2;
                        }
                        else
                        {
                            historia = _historia.UpdateHistoria(history);
                            mensaje = 3;
                            return RedirectToPage("./Asignacion");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        mensaje = 1;
                        throw;
                    }
                    historia = _historia.GetHistoria(id);
                    ninos = _nino.GetAllPersonas();
                    familiares = _familiar.GetAllFamiliares();
                    medicos = _medico.GetAllPersonas();
                    if (historia==null)
                    {
                        return RedirectToPage("../Error");
                    }
                    return Page();
                
                default:
                    return RedirectToPage("../Error");
            }
        }
    }
}