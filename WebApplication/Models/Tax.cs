namespace WebApplication.Models
{
    public class Tax
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Porcentage { get; set; }

        public string TaxType { get; set; }

        public Tax(int id, string description, int porcentage, string taxType)
        {
            Id = id;
            Description = description;
            Porcentage = porcentage;
            TaxType = taxType;
        }
    }
}