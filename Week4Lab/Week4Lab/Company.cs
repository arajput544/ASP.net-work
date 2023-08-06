using System;
using System.Collections.Generic;
using System.Text;

namespace Week4Lab
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateHired { get; set; }
        public int? SupervisorId { get; set; }

        public Employee() { }

        public Employee(int id, string firstName, string lastName, DateTime dateHired, int? supervisorId = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateHired = dateHired;
            SupervisorId = supervisorId;
        }

        public override string ToString()
        {
            return $"{Id}, {FirstName} {LastName}, {DateHired:d}, {SupervisorId}";
        }
    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Leader { get; set; }
        public List<Employee> Members { get; set; }

        public Project()
        {
            Members = new List<Employee>();
        }

        public Project(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }

    public class Company
    {
        public List<Employee> Employees { get; set; }
        public List<Project> Projects { get; set; }

        public Company()
        {
            var john = new Employee(1, "John", "Doe", new DateTime(2015, 1, 10));
            var jane = new Employee(2, "Jane", "Doe", new DateTime(2015, 2, 20), 1);
            var tom = new Employee(3, "Tom", "Smith", new DateTime(2016, 6, 19), 2);
            var bob = new Employee(4, "Bob", "Lee", new DateTime(2016, 6, 20), 2);

            Employees = new List<Employee>();
            Employees.Add(john);
            Employees.Add(jane);
            Employees.Add(tom);
            Employees.Add(bob);

            var firestone = new Project(1, "Firestone")
            {
                Leader = john,
                Members = new List<Employee> { john }
            };
            var blue = new Project(2, "Blue")
            {
                Leader = jane,
                Members = new List<Employee> { john, jane }
            };

            Projects = new List<Project>();
            Projects.Add(firestone);
            Projects.Add(blue);
        }
    }
}
