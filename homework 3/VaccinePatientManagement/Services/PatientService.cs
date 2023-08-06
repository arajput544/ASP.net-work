using Microsoft.EntityFrameworkCore;
using VaccinePatientManagement.Models;

namespace VaccinePatientManagement.Services
{
    public interface IPatientService
    {
        List<Patient> GetPatients();
        void AddPatient(string name, int vaccine);
        Patient GetPatient(int id);
        void UpdateSecondDose(int id);
    }

    public class PatientService : IPatientService
    {
        private readonly AppDbContext _db;

        public PatientService(AppDbContext db)
        {
            _db = db;
        }

        public void AddPatient(string name, int vaccine)
        {
            var vac = _db.Vaccines.Where(v => v.Id == vaccine).SingleOrDefault();
            var patient = new Patient { Name = name, Dose = vac, FirstDose = DateTime.Now };
            vac.TotalDosesLeft = vac.TotalDosesLeft - 1;
            _db.Patients.Add(patient);
            _db.SaveChanges();
        }

        public Patient GetPatient(int id)
        {
            return _db.Patients.Where(v => v.Id == id).SingleOrDefault();
        }

        public List<Patient> GetPatients()
        {
            try
            {
                return _db.Patients.Include("Dose").ToList();
            }
            catch (Exception ex)
            {
                return new List<Patient>();
            }
        }

        public void UpdateSecondDose(int id)
        {
            var patient = _db.Patients.Include("Dose").Where(p => p.Id == id).SingleOrDefault();
            string dT = DateTime.Now.ToString("d");
            patient.SecondDose = dT;
            patient.Dose.TotalDosesLeft = patient.Dose.TotalDosesLeft - 1;
            _db.SaveChanges();
        }
    }
   
}
