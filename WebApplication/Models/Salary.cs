using System.Security.Cryptography;

namespace WebApplication.Models
{
    public class Salary
    {
        public Salary()
        {
        }

        public Salary(int salaryId, double grossIncome, int month, int year)
        {
            SalaryId = salaryId;
            GrossIncome = grossIncome;
            Month = month;
            Year = year;
            SalaryItems = new List<SalaryItem>();
        }


        public int SalaryId { get; set; }
        public double GrossIncome { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public List<SalaryItem> SalaryItems{ get; set; }

        public void Add(SalaryItem item)
        {
            SalaryItems.Add(item);
        }


        public double NetIncome()
        {
            double aux = 0;

            foreach(SalaryItem salaryItem in SalaryItems)
            {
                if(salaryItem.Tax.TaxType.Equals("r"))
                    aux -= salaryItem.Amount;
                if (salaryItem.Tax.TaxType.Equals("CNR") || salaryItem.Tax.TaxType.Equals("CR"))
                    aux += salaryItem.Amount;
            }
            return GrossIncome - aux;

        }
        
    }
}
