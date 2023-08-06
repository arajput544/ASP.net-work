using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineWithEF
{
    class ViewController
    {
        public void VaccineListDisplay()
        {
            using var db = new AppDBContext();

            var vaccines = db.Vaccines.ToList();
               
          
            while (true)
            {
          
                Console.WriteLine("Vaccine Management");
                Console.WriteLine("     Name                Doses Required      Days Between Doses  Total Doses Received");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                foreach (Vaccine vaccine in vaccines)
                {
                    if (vaccine == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{vaccine.Id})  {vaccine.Name.PadRight(20)} {vaccine.DosesAmount.ToString().PadRight(20)} {vaccine.DaysBetweenDoses.ToString().PadRight(20)} {vaccine.TotalDosesRec}");
                        //count++;
                    }
                }

                Console.WriteLine("a) Add Vaccine");
                Console.WriteLine("x) Close Application");
                Console.WriteLine("Please enter your choice:");

                string choice = Console.ReadLine();
                vaccineListChoice(choice.ToLower());
            }
        }

        private void vaccineListChoice(string choice)
        {
            using var db = new AppDBContext();

            int choiceAsNum;
            var isNumeric = int.TryParse(choice, out choiceAsNum);

            if (isNumeric == true && db.Vaccines.Find(choiceAsNum) != null)
            {
                var userChoice = db.Vaccines.Find(choiceAsNum);
                Console.WriteLine();
                Console.WriteLine($"Vaccine Management - {userChoice.Name}");
                Console.WriteLine("Please enter how many new doses are received:");
                string input = Console.ReadLine();
                int amount = Int32.Parse(input);
                vaccineTotalChoice(choiceAsNum, amount);

                Console.WriteLine();
                VaccineListDisplay();
            }

            else if (choice == "a")
            {
                Console.WriteLine();
                Console.WriteLine("Please, Enter the name of the vaccine: ");
                string nameInput = Console.ReadLine();

                Console.WriteLine("Please, Enter the number of doses for this vaccine:");
                string dAInput = Console.ReadLine();
                int doseAmountIn = Int32.Parse(dAInput);

                Console.WriteLine("Please, Enter the total doses recieved for this vaccine:");
                string tDInput = Console.ReadLine();
                int totalDosesRecIn = Int32.Parse(tDInput);

                if (doseAmountIn >= 2)
                {
                    Console.WriteLine("Please enter the days between doses:");
                    string response = Console.ReadLine();
                    int dosesBetween = Int32.Parse(response);
                    addNewVaccine(nameInput, doseAmountIn, totalDosesRecIn, dosesBetween);

                }

                else
                {
                    addNewVaccine(nameInput, doseAmountIn, totalDosesRecIn);
                }

                Console.WriteLine();
                VaccineListDisplay();
            }

            else
            {
                System.Environment.Exit(1);
            }
        }

        private void vaccineTotalChoice(int choice, int amount)
        {
            using var db = new AppDBContext();

            var vaccine = db.Vaccines.Find(choice);
            int newTotal = vaccine.TotalDosesRec + amount;
            vaccine.TotalDosesRec = newTotal;
            db.SaveChanges();

        }

        private void addNewVaccine(string Name, int doseAmount, int totalDosage, int dosesBetween = 0)
        {
            using var db = new AppDBContext();

            var vac = new Vaccine
            {
                Name = Name,
                DosesAmount = doseAmount,
                DaysBetweenDoses = dosesBetween,
                TotalDosesRec = totalDosage
            };
            db.Vaccines.Add(vac);
            db.SaveChanges();
        }

    }
}
