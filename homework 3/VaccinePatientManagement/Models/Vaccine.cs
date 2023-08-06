namespace VaccinePatientManagement.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DosesRequired { get; set; }
        public int? DaysBetweenDoses { get; set; }

        public int TotalDosesRecieved { get; set; }

        public int TotalDosesLeft { get; set; }

        public Vaccine() { }

        public Vaccine(int id, string name, int dosesRequired, int? daysBetweenDoses, int totalDosesRecieved, int totalDosesLeft)
        {
            Id = id;
            Name = name;
            DosesRequired = dosesRequired;
            DaysBetweenDoses = daysBetweenDoses;
            TotalDosesRecieved = totalDosesRecieved;
            TotalDosesLeft = totalDosesLeft;


        }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
