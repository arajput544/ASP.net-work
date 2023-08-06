using Homework2.Models;
using Homework2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework2.Controllers
{
    public class VaccinesController : Controller
    {
        private readonly IVaccineService _vaccineService;

        public VaccinesController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }
        public IActionResult Index()
        {
            return View(_vaccineService.GetVaccines());
        }
            
        [HttpGet]
        public IActionResult EditVaccine(int id)
        {
            return View(_vaccineService.GetVaccine(id));
        }

        [HttpPost]
        public IActionResult EditVaccine(int id, string Name, int DosesRequired, int? DaysBetweenDoses)
        {
            _vaccineService.EditVaccine(id, Name, DosesRequired, DaysBetweenDoses);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult NewDoses()
        {
            return View(_vaccineService.GetVaccines());
        }

        [HttpPost]
        public IActionResult NewDoses(int Vaccine, int NewDosesReceived)
        {
            _vaccineService.UpdateDoses(Vaccine, NewDosesReceived);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddVaccine()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVaccine(Vaccine vaccine)
        {
            _vaccineService.AddVaccine(vaccine);
            return RedirectToAction("Index");

        }
    }
}
