using Microsoft.AspNetCore.Mvc;
using VaccinePatientManagement.Services;

namespace VaccinePatientManagement.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IVaccineService _vaccineService;

        public PatientsController(IPatientService patientService, IVaccineService vaccineService)
        {
            _patientService = patientService;
            _vaccineService = vaccineService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _patientService.GetPatients();
            return View(list);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            _patientService.UpdateSecondDose(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult NewPatient()
        {
            var list = _vaccineService.GetVaccines();
            return View(list);
        }

        [HttpPost]
        public IActionResult NewPatient(string Name, int Vaccine)
        {
            _patientService.AddPatient(Name, Vaccine);
            return RedirectToAction("Index");
        }
    }
}
