using System;

namespace HogarGestor.App.Dominio
{
    public class Nino:Persona
    {
        public string Direccion { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public string Ciudad { get; set; }
        public DateTime Nacimiento { get; set; }
        public PatronesCrecimiento PatronesCrecimiento { get; set; }
    }
}