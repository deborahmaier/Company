namespace WebApplication.Models
{
    public class SalaryItem
    {
        public Tax Tax{ get; set; }
        public double Amount { get; set; }

        public SalaryItem(Tax tax, double amount)
        {
            Tax = tax;
            Amount = amount;
        }
    }
}