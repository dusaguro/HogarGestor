namespace HogarGestor.App.Dominio
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public string Diagnostico { get; set; }
        public Medico Medico { get; set; }
        public Familiar Familiar { get; set; }
        public Nino Nino { get; set; }
        public SugerenciasCuidado SugerenciasCuidado { get; set; }
    }
}