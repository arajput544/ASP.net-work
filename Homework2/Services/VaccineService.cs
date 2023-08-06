using Homework2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2.Services
{
    public interface IVaccineService
    {
        List<Vaccine> GetVaccines();
        Vaccine GetVaccine(int id);
        void UpdateDoses(int id, int newDoses);
        void AddVaccine(Vaccine vaccine);
        void EditVaccine(int id, string name, int dosesRequired, int? daysBetweenDoses);
    }
    public class VaccineService : IVaccineService   
    {
        private readonly AppDbContext _db;

        public VaccineService(AppDbContext db)
        {
            _db = db;
        }
        public List<Vaccine> GetVaccines()
        {
            try
            {
                return _db.Vaccines.ToList();
            }
            catch (Exception ex)
            {
                return new List<Vaccine>();
            }

        }

        
        public Vaccine GetVaccine(int id)
        {
            return _db.Vaccines.Where(v => v.Id == id).SingleOrDefault();
        }

        
        public void UpdateDoses(int id, int newDoses)
        {
            var current = _db.Vaccines.Where(v => v.Id == id).SingleOrDefault();
            var newDoseAmount = current.TotalDosesRecieved + newDoses;
            var remainingDoses = current.TotalDosesLeft + newDoses;
            current.TotalDosesRecieved = newDoseAmount;
            current.TotalDosesLeft = remainingDoses;
            _db.SaveChanges();
        }


      
        public void AddVaccine(Vaccine vaccine)
        {
            _db.Vaccines.Add(vaccine);
            _db.SaveChanges();
        }

        public void EditVaccine(int id, string name, int dosesRequired, int? daysBetweenDoses)
        {
            var vaccine = _db.Vaccines.Where(v => v.Id == id).SingleOrDefault();
            vaccine.Name = name;
            vaccine.DosesRequired = dosesRequired;
            vaccine.DaysBetweenDoses = daysBetweenDoses;
            _db.SaveChanges();
        }
    }
}
