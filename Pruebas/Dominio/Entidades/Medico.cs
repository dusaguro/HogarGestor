namespace HogarGestor.App.Dominio
{
    public class Medico:Persona
    {
        public string Codigo { get; set; }
        public string RegistroRethus { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}