using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Registros
{
    public class prueba : PageModel
    {
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
            Console.WriteLine(Request.Form["guardar"] + Request.Form["enviar"]);
            
        }
    }
}