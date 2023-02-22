using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudHospitalesEF.Models;
using MvcCoreCrudHospitalesEF.Repository;

namespace MvcCoreCrudHospitalesEF.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospitales repo;

        public HospitalesController(RepositoryHospitales repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Hospital> hospitales =
            this.repo.GetHospitales();
            return View(hospitales);

        }

        public IActionResult Details(int idhospital)
        {
            Hospital hospitales =
                this.repo.FindHospital(idhospital);
            return View(hospitales);
        }
    }
}
