using System;

namespace HogarGestor.App.Dominio
{
    public class PatronesCrecimiento
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public Patron Patron { get; set; }
    }
}