using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Personnel
    {
        public int PersonnelId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public DateTime JoinedDate { get; set; }
        public int WorkingHours { get; set; }
        public string Department { get; set; }        
        public double GrossIncome { get; set; }
        //public List<Salary> Salaries { get; set; }


        public Personnel(int personnelId, string name, string surname, DateTime birthdate, string adress, string zipCode, DateTime joinedDate, int workingHours, string department)
        {
            this.PersonnelId = personnelId;
            this.Name = name;
            this.Surname = surname;
            this.Birthdate = birthdate;
            this.Adress = adress;
            this.ZipCode = zipCode;
            this.JoinedDate = joinedDate;
            this.WorkingHours = workingHours;
            this.Department = department;
        }

        public Personnel()
        {
        }

   

    }
}
