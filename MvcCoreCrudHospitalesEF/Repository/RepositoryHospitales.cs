using MvcCoreCrudHospitalesEF.Data;
using MvcCoreCrudHospitalesEF.Models;

namespace MvcCoreCrudHospitalesEF.Repository
{
    public class RepositoryHospitales
    {
        private HospitalesContext context;

        public RepositoryHospitales(HospitalesContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }

        public Hospital FindHospital(int idhospital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == idhospital
                           select datos;
            return consulta.FirstOrDefault();
        }

        public async Task InsertHospitalAsync
       (int idhospital, string nombre, string direccion, string telefono, int numcama)
        {

            Hospital hospital = new Hospital();

            hospital.IdHospital = idhospital;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.numcama = numcama;

            this.context.Hospitales.Add(hospital);
           
            await this.context.SaveChangesAsync();
        }


        public async Task UpdateHospitalAsync
      (int idhospital, string nombre, string direccion, string telefono, int numcama)
        {
  
            Hospital hospital = this.FindHospital(idhospital);

         
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.numcama = numcama;


            await this.context.SaveChangesAsync();
        }

        public async Task DeleteHospitalAsync(int idhospital)
        {

            Hospital hospital = this.FindHospital(idhospital);
            //BORRAMOS EL DEPARTAMENTO DE LA COLECCION DE CONTEXT
            this.context.Hospitales.Remove(hospital);
            //GUARDAMOS CAMBIOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }
    }



}
