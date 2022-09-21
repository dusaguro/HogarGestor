using System;

namespace HogarGestor.App.Dominio
{
    public class SignosVitales
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public float Oximetria { get; set; }
        public float FrecCardiada { get; set; }
        public float FrecRespiratoria { get; set; }
        public float Temperatura { get; set; }
        public float PresArterial { get; set; }
        public float Glicemia { get; set; }
    }
}