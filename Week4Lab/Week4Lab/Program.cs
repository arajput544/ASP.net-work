using System;
using System.Collections.Generic;
using System.Linq;

namespace Week4Lab
{
    class Program
    {
        static void Print<T>(string label, IEnumerable<T> results)
        {
            Console.WriteLine(label);
            foreach (var result in results)
                Console.WriteLine("\t{0}", result);
        }

        static void Main(string[] args)
        {
            Company c = new Company();

            // 1. List the names of the employees who do not have a supervisor.
            // The results should combine FirstName and LastName into one string.
            var employeesWithoutSupervisor = c.Employees
                .Where(emp => emp.SupervisorId == null)
                .Select(emp => $"{emp.FirstName} {emp.LastName}");
            Print("Employees without supervisor:", employeesWithoutSupervisor);

            // 2. List the last names of the employees whose last name starts with D.
            // The results should be listed in alphabetical order without duplicates.
            var lastNamesStartingWithD = c.Employees
                .Where(emp => emp.LastName.StartsWith("D"))
                .Select(emp => emp.LastName)
                .Distinct()
                .OrderBy(ln => ln);
            Print("Last names starting with D:", lastNamesStartingWithD);

            // 3. List the names of the employees who are on the project Blue.
            // The results should combine FirstName and LastName into one string.
            var employeesOnProjectBlue = c.Projects
                .Where(proj => proj.Name == "Blue")
                .SelectMany(proj => proj.Members)
                .Select(emp => $"{emp.FirstName} {emp.LastName}");
            Print("Employees on project Blue:", employeesOnProjectBlue);

            

            // 4. Find Jane Doe's subordinates, i.e. the employees who are supervised by Jane Doe.
            var janeSubordinates = c.Employees
                .Where(e => e.SupervisorId == c.Employees
                    .FirstOrDefault(s => s.FirstName == "Jane" && s.LastName == "Doe")?.Id)
                .Select(e => $"{e.FirstName} {e.LastName}");
            Print("Jane Doe's subordinates:", janeSubordinates);

            //var janeSubordinates = c.Employees
            //    .Where(emp => emp.SupervisorId.HasValue && emp.SupervisorId.Value == 2)
            //    .Select(emp => $"{emp.FirstName} {emp.LastName}");
            //Print("Jane Doe's subordinates:", janeSubordinates);

            // 5. Find the employee(s) who were hired in 2015 and worked on the project Blue.
            var employees2015OnProjectBlue = c.Employees
                .Where(emp => emp.DateHired.Year == 2015 && c.Projects.Any(proj => proj.Name == "Blue" && proj.Members.Contains(emp)))
                .Select(emp => $"{emp.FirstName} {emp.LastName}");
            Print("Employees hired in 2015 and worked on project Blue:", employees2015OnProjectBlue);
        }
    }
}
