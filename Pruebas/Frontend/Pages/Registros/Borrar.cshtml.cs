using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Registros
{
    public class Borrar : PageModel
    {
        private readonly IRepositorioNino _nino = new RepositorioNino(new AppDbContext());
        private readonly IRepositorioMedicos _medico = new RepositorioMedicos(new AppDbContext());
        private readonly IRepositorioFamiliares _familiar = new RepositorioFamiliares(new AppDbContext());
        public Nino nino { get; set; }
        public Medico medico { get; set; }
        public Familiar familiar { get; set; }
        
        public IActionResult OnGet(int id, string tipo)
        {
            
            switch (tipo)
            {
                case "nino":
                    nino = _nino.GetPersona(id);
                    if (nino==null)
                    {
                        return RedirectToPage("./Pages/Error");
                    }
                    return Page();
                
                case "medico":
                    medico = _medico.GetPersona(id);
                    if (medico==null)
                    {
                        return RedirectToPage("./Pages/Error");
                    }
                    return Page();
                
                case "familiar":
                    familiar = _familiar.GetFamiliar(id);
                    if (medico!=null)
                    {
                        return RedirectToPage("./Pages/Error");
                    }
                    return Page();
                
                default:
                    return RedirectToPage("./Pages/Error");
                
            }
        }

        public IActionResult OnPost(int id, string tipo)
        {   
            
            switch (tipo)
            {
                case "nino":
                    if (Request.Form["Si, Borrar Registro"]=="Si, Borrar Registro")
                    {
                        _nino.DeletePersona(id);
                        return RedirectToPage("./Pacientes");
                    }
                    nino = _nino.GetPersona(id);
                    if (nino==null)
                    {
                        return RedirectToPage("./Pages/Error");
                    }
                    return Page();
                
                case "medico":
                    if (Request.Form["Si, Borrar Registro"]=="Si, Borrar Registro")
                    {
                        _medico.DeletePersona(id);
                        return RedirectToPage("./Medicos");
                    }
                    medico = _medico.GetPersona(id);
                    if (medico==null)
                    {
                        return RedirectToPage("./Pages/Error");
                    }
                    return Page();
                
                case "familiar":
                    if (Request.Form["Si, Borrar Registro"]=="Si, Borrar Registro")
                    {
                        _familiar.DeleteFamiliar(id);
                        return RedirectToPage("./Familiares");
                    }
                    familiar = _familiar.GetFamiliar(id);
                    if (medico!=null)
                    {
                        return RedirectToPage("./Pages/Error");
                    }
                    return Page();
                
                default:
                    return RedirectToPage("./Pages/Error");
                
            }
        }
    }
}