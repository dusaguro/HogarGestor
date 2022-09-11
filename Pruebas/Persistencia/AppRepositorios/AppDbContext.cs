using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using HogarGestor.App.Dominio;

namespace HogarGestor.App.Pericistencia
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Persona> Personas { get; set; }
        public DbSet<Familiar> Familiares { get; set; }
        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Nino> Ninos { get; set; }
        public DbSet<PatronesCrecimiento> PatronesCrecimientos { get; set; }
        public DbSet<RegistroHistorico> RegistrosHistoricos { get; set; }
        public DbSet<SugerenciasCuidado> SugerenciasCuidados { get; set; }
        
        public DbSet<Campos> NombresCampos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
			if(!optionsBuilder.IsConfigured){
			optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HogarGestorDB");
			}
		}
    }
}