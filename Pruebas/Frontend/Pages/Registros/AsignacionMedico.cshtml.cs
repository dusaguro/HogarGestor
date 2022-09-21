using System;
using System.Collections.Generic;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Registros
{
    public class AsignacionMedico : PageModel
    {
        private readonly IRepositorioHistoriaClinica _historia = new RepositorioHistoriaClinica(new AppDbContext());
        private readonly IRepositorioNino _nino = new RepositorioNino(new AppDbContext());

        public List<Nino> ninos = new List<Nino>();
        public IEnumerable<HistoriaClinica> historias { get; set; }
        
        public IActionResult OnGet(int id)
        {
            historias = _historia.GetHistoriaMedico(id);
            if (historias==null)
            {
                return RedirectToPage("../Error");
            }
            foreach (var x in historias)
            {
                ninos.Add(_nino.GetPersonaById(x.idNino));
            }
            
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            historias = _historia.GetHistoriaMedico(id);
            if (historias==null)
            {
                return RedirectToPage("../Error");
            }
            foreach (var x in historias)
            {
                ninos.Add(_nino.GetPersonaById(x.idNino));
            }
            return Page();
        }
    }
}