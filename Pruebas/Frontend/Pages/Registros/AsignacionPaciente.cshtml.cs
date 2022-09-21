using System;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Registros
{
    public class AsignacionPaciente : PageModel
    {
        private readonly IRepositorioHistoriaClinica _historia = new RepositorioHistoriaClinica(new AppDbContext());
        private readonly IRepositorioNino _nino = new RepositorioNino(new AppDbContext());
        private readonly IRepositorioFamiliares _familiar = new RepositorioFamiliares(new AppDbContext());
        private readonly IRepositorioMedicos _medico = new RepositorioMedicos(new AppDbContext());
        private readonly IRepositorioSignosVitales _signo = new RepositorioSignosVitales(new AppDbContext());

        private readonly IRepositorioSugerenciasCuidado _sugerencia =
            new RepositorioSugerenciasCuidado(new AppDbContext());
        
        public Medico medico { get; set; }
        public Nino nino { get; set; }
        public Familiar familiar { get; set; }
        public HistoriaClinica historia { get; set; }
        public SugerenciasCuidado sugerencia { get; set; }
        public SignosVitales signo { get; set; }
        
        public int mensaje;
        
        
        
        public IActionResult OnGet(int id)
        {
            historia = _historia.GetHistoriaNino(id);
            if (historia==null)
            {
                return RedirectToPage("../Error");
            }
            sugerencia = _sugerencia.GetSugerencia(historia.idSugerenciasCuidado);
            nino = _nino.GetPersonaById(historia.idNino);
            familiar = _familiar.GetFamiliar(historia.idFamiliar);
            medico = _medico.GetPersona(historia.idMedico);
            signo = _signo.GetSignos(nino.idSignosVitales);
            
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            historia = _historia.GetHistoriaNino(id);
            nino = _nino.GetPersonaById(historia.idNino);
            familiar = _familiar.GetFamiliar(historia.idFamiliar);
            medico = _medico.GetPersona(historia.idMedico);
            sugerencia = _sugerencia.GetSugerencia(historia.idSugerenciasCuidado);
            signo = _signo.GetSignos(nino.idSignosVitales);
            try
            {
                historia.Diagnostico = Request.Form["diag"];
                
                signo.FrecCardiada = int.Parse(Request.Form["fc"]);
                signo.FrecRespiratoria = int.Parse(Request.Form["fr"]);
                signo.Oximetria = int.Parse(Request.Form["ox"]);
                signo.Temperatura = int.Parse(Request.Form["te"]);
                signo.PresArterial = int.Parse(Request.Form["pa"]);
                signo.Glicemia = int.Parse(Request.Form["gl"]);
                
                if (historia.Diagnostico.Equals(""))
                {
                    mensaje = 2;
                }
                else
                {
                    signo = _signo.UpSignos(signo);
                    historia = _historia.UpdateHistoria(historia);
                    mensaje = 3;
                    return RedirectToPage("./Pacientes");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                mensaje = 1;
            }
            if (historia==null)
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}