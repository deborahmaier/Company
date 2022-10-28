
using WebApplication.Models;

namespace WebApplication.data
{
    public interface IPersonnelRepository
    {
        bool Create(Personnel oPersonnel);
        List<Personnel> GetAll();

        List<Salary> GetSalariesById(int id);

        bool Update(Personnel oPersonnel);
        bool Delete(int id);
    }
}
