using MvcCoreCrudHospitalesEF.Data;
using MvcCoreCrudHospitalesEF.Models;

namespace MvcCoreCrudHospitalesEF.Repository
{
    public class RepositoryEmpleados
    {

        private HospitalesContext context;

        public RepositoryEmpleados(HospitalesContext context)
        {
            this.context = context;
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return consulta.ToList();
        }

        public async Task<ModelEmpleados> IncrementarSalariosAsync
            (int incremento, string oficio)
        {
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);
            foreach (Empleado empleado in empleados)
            {
                empleado.Salario += incremento;
            }
            await this.context.SaveChangesAsync();
            //DEVOLVER LOS EMPLEADOS, LA MEDIA Y LA SUMA SALARIAL
            int suma = empleados.Sum(z => z.Salario);
            double media = empleados.Average(z => z.Salario);
            ModelEmpleados model = new ModelEmpleados();
            model.SumaSalarial = suma;
            model.MediaSalarial = media;
            model.Empleados = empleados;
            return model;
        }


    }
}
