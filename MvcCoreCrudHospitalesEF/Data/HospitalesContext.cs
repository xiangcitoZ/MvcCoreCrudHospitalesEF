using Microsoft.EntityFrameworkCore;
using MvcCoreCrudHospitalesEF.Models;

namespace MvcCoreCrudHospitalesEF.Data
{
    public class HospitalesContext : DbContext
    {

        public HospitalesContext(DbContextOptions<HospitalesContext> options)
            : base(options) { }

        public DbSet<Hospital> Hospitales { get; set; }

        public DbSet<Empleado> Empleados { get; set; }


    }
}
