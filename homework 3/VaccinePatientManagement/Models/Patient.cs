namespace VaccinePatientManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vaccine Dose { get; set; }
        public DateTime FirstDose { get; set; }
        public string? SecondDose { get; set; }

        public Patient()
        {

        }

        public Patient(int id, string name, Vaccine dose, DateTime firstDose, string? secondDose)
        {
            Id = id;
            Name = name;
            Dose = dose;
            FirstDose = firstDose;
            SecondDose = secondDose;
        }
    }
}
