using System;
using System.Collections.Generic;
using HogarGestor.App.Dominio;
using HogarGestor.App.Pericistencia;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Frontend.Pages.Registros
{
    public class prueba : PageModel
    {
        private IRepositorioNino _nino = new RepositorioNino(new AppDbContext());
        // private IRepCampos _campos = new RepCampos(new AppDbContext());
        public IEnumerable<Nino> ninos { get; set; }

        public int caso;
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            /*if (Request.Form["enviar"]=="enviar")
            {
                Console.WriteLine("BotonPost: " + Request.Form["enviar"]);
            }
            
            if (Request.Form["guardar"]=="guardar")
            {
                Console.WriteLine("BotonPost: " + Request.Form["guardar"]);
            }*/
            /*Console.WriteLine(Request.Form["guardar"] + Request.Form["enviar"]);*/
            
        }
    }
}