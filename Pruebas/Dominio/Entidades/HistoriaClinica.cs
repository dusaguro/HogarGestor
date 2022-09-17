namespace HogarGestor.App.Dominio
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public string Diagnostico { get; set; }
        public int idMedico { get; set; }
        public int idFamiliar { get; set; }
        public int idNino { get; set; }
        public int idSugerenciasCuidado { get; set; }
    }
}