using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Personnel
    {
        public int PersonnelId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; }
        public string BirthPlace { get; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public DateTime JoinedDate { get; set; }
        public int WorkingHours { get; set; }
        public int GrossIncome { get; set; }
        public string Department { get; set; }


        public Personnel(int personnelId, string name, string surname, DateTime birthdate, string birthPlace, string adress, string zipCode, DateTime joinedDate, int workingHours, int grossIncome, string department)
        {
            this.PersonnelId = personnelId;
            this.Name = name;
            this.Surname = surname;
            this.Birthdate = birthdate;
            this.BirthPlace = birthPlace;
            this.Adress = adress;
            this.ZipCode = zipCode;
            this.JoinedDate = joinedDate;
            this.WorkingHours = workingHours;
            this.GrossIncome = grossIncome;
            this.Department = department;
        }
    }
}
