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

        public List<Salary> Salaries { get; set; }


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
            this.Salaries = new List<Salary>();
        }            
        
        //public static DataTable createDataTable()
        //{
        //    DataTable dt = new DataTable();
        //    foreach (DataGridViewColumn column in dataGridView1.Columns)
        //    {
        //        dt.Columns.Add(column.HeaderText, column.ValueType);
        //    }
        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        dt.Rows.Add();
        //        foreach (DataGridViewCell cell in row.Cells)
        //        {
        //            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
        //        }
        //    }
        //    return dt;
        //}

        public void Add(Salary salary)
        {
            Salaries.Add(salary);
        }

    }
}
