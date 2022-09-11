using System.Collections.Generic;
using System.Linq;
using HogarGestor.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HogarGestor.App.Pericistencia
{
    public class RepCampos : IRepCampos
    {
        private readonly AppDbContext _appDbContext;

        public RepCampos(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Campos> obtenercampos()
        {
            return _appDbContext.NombresCampos.FromSqlRaw("USE [HogarGestorDB] SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Ninos' AND TABLE_SCHEMA='dbo'").ToList();
        }
    }
}