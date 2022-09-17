using System;
using System.Collections.Generic;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Registros
{
    public class Asignacion : PageModel
    {
        private IRepositorioFamiliares _familiares = new RepositorioFamiliares(new AppDbContext());
        private IRepositorioMedicos _medicos = new RepositorioMedicos(new AppDbContext());
        private IRepositorioNino _ninos = new RepositorioNino(new AppDbContext());
        private IRepositorioHistoriaClinica _historias = new RepositorioHistoriaClinica(new AppDbContext());
        public IEnumerable<Familiar> familliares { get; set; }
        public IEnumerable<Medico> medicos { get; set; }
        public IEnumerable<Nino> ninos { get; set; }
        public IEnumerable<HistoriaClinica> historias { get; set; }
        public int mensaje;

        public void OnGet()
        {
            ninos = _ninos.GetAllPersonas();
            familliares = _familiares.GetAllFamiliares();
            medicos = _medicos.GetAllPersonas();
            historias = _historias.GetAllHistorias();
            
        }

        public void OnPost()
        {
            ninos = _ninos.GetAllPersonas();
            familliares = _familiares.GetAllFamiliares();
            medicos = _medicos.GetAllPersonas();
            historias = _historias.GetAllHistorias();

            try
            {
                var history = new HistoriaClinica();
                history.idNino = int.Parse(Request.Form["paciente"]);
                history.idFamiliar = int.Parse(Request.Form["familiar"]);
                history.idMedico = int.Parse(Request.Form["medico"]);
                history.Diagnostico = Request.Form["diagnostico"];
                if (history.idNino==0||history.idFamiliar==0||history.idMedico==0)
                {
                    mensaje = 1;
                }
                else
                {
                    _historias.AddHistoria(history);
                    mensaje = 2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                mensaje = 3;
                throw;
            }
        }
    }
}