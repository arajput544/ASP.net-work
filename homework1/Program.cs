using System;

namespace VaccineWithEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("I am in program.cs");
            var driver = new ViewController();
            driver.VaccineListDisplay();
        }
    }
}