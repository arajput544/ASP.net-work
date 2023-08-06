using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineWithEF
{
    public class Vaccine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DosesAmount { get; set; }
        public int DaysBetweenDoses { get; set; }
        public int TotalDosesRec { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {DosesAmount}, {DaysBetweenDoses}, {TotalDosesRec}";
        }

        /*        public void AddTotalDosesRec(int addition)
                {
                    TotalDosesRec += addition;
                }*/
    }
}
