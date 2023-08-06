using System;

namespace vaccine;

public class Vaccine
{

    public string Name { get; set; }
    public int DosesRequired { get; set; }
    public int? DaysBetweenDoses { get; set; }
    public int TotalDosesReceived { get; set; }

}

public class VaccineDataStore
{
    private List<Vaccine> vaccines;

    public VaccineDataStore() 
    {
        vaccines = new List<Vaccine>
        {
            new Vaccine { Name = "Pfizer/BioNTech", DosesRequired = 2, DaysBetweenDoses = 21, TotalDosesReceived = 10000 },
            new Vaccine { Name = "Johnson & Johnson", DosesRequired = 1, TotalDosesReceived = 5000 }
        };
    }
    public List<Vaccine> GetVaccines()
    {
        return vaccines;
    }

    public void AddNewDoses(int vaccineIndex, int newDoses)
    {
        vaccines[vaccineIndex].TotalDosesReceived += newDoses;
    }

    public void AddNewVaccine(Vaccine newVaccine)
    {
        vaccines.Add(newVaccine);
    }

 
}

public class VaccineController 
{
    private VaccineDataStore dataStore;

    public VaccineController()
    {
        dataStore = new VaccineDataStore();
    }

    public void DisplayVaccineList()
    {
        List<Vaccine> vaccines = dataStore.GetVaccines();
        Console.WriteLine("Vaccine Management");
        Console.WriteLine("     Name                Doses Required      Days Between Doses  Total Doses Received");
        Console.WriteLine("-------------------------------------------------------------------------------------");
        for(int i=0; i<vaccines.Count; i++) 
        { 
            Vaccine vaccine = vaccines[i];
            Console.WriteLine($"{i+1})   {vaccine.Name.PadRight(20)} {vaccine.DosesRequired.ToString().PadRight(20)} {vaccine.DaysBetweenDoses.ToString().PadRight(17)} {vaccine.TotalDosesReceived}");
        }

        Console.WriteLine("a) Add a new vaccine");
        Console.WriteLine("x) Exit");
        Console.WriteLine("Please enter your choice: ");
    }

    public void AddNewDose(int vaccineIndex)
    {
        Console.WriteLine($"\nVaccine Management - {dataStore.GetVaccines()[vaccineIndex].Name}\n");
        Console.Write("\n Please enter how many new doses are received: ");
        int newDoses = Convert.ToInt32(Console.ReadLine());

        dataStore.AddNewDoses(vaccineIndex, newDoses);


    }

    public void AddNewVaccine()
    {
        Vaccine newvaccine;
        Console.WriteLine("Please, Enter the name of the vaccine: ");
        string name = Console.ReadLine();

        Console.WriteLine("Please, Enter the number of doses required");
        int dosesRequired = Convert.ToInt32(Console.ReadLine());
        int daysBetweenDoses = 0;
        while( true )
        {
            if (dosesRequired >= 2)
            {
                Console.WriteLine("Please Enter the days between Doses:");
                daysBetweenDoses = Convert.ToInt32(Console.ReadLine());
                break;

            }
            else if (dosesRequired ==1 )
            {
                break;
            }
        }
        Console.WriteLine("Enter the number of doses recieved ");
        int totalDosesRecieved = Convert.ToInt32(Console.ReadLine());
        newvaccine = new Vaccine { Name = name, DosesRequired=dosesRequired , DaysBetweenDoses= daysBetweenDoses, TotalDosesReceived=totalDosesRecieved };
        dataStore.AddNewVaccine(newvaccine);
        Console.WriteLine("New Vaccine added successfully");
    }

    public List<Vaccine> GetVaccines()
    {
        return dataStore.GetVaccines();
    }
}

class Program
{
    private static void Main(string[] args)
    {   
        VaccineController controller = new VaccineController();
        while(true)
        {
            controller.DisplayVaccineList();
            string choice = Console.ReadLine();
            
            if(choice.ToLower() == "x")
            {
                break;
            }
            else if(choice.ToLower() == "a")
            {
                controller.AddNewVaccine();
            }
            else
            {
                int vaccineIndex = Convert.ToInt32(choice) - 1;
                if(vaccineIndex>=0 && vaccineIndex<controller.GetVaccines().Count)
                {
                    controller.AddNewDose(vaccineIndex);
                }
                else
                {
                    Console.WriteLine("Invalid Choice|");
                }
            }
        }
    }

}
    
