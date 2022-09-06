using System;

namespace Dominio.MisFunciones
{
    public class MisFunciones
    {
        public static string limitefecha()
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
            
            return yyyy + "-" + mm + "-" + dd;
        }
    }
}