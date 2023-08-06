using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DosesAmount { get; set; }
        public int DaysBetweenDoses { get; set; }
        public int TotalDosesRec { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {DosesAmount}, {DaysBetweenDoses}, {TotalDosesRec}";
        }

        
    }
}