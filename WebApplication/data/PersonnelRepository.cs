using System.Data.SqlClient;
using System.Data;
using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace WebApplication.data
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private readonly IConfiguration _config;
        private string connectionString = "Data Source=DEBORAH\\SQLEXPRESS;Initial Catalog = Company; Integrated Security = True";

        public PersonnelRepository()
        {
            //this._config = config;
        }


        public bool Create(Personnel oPersonnel)
        {
            int rows = 0;
            string query = @"
                             insert into dbo.Personnel 
                             (Name, Surname, Birthdate, Adress, ZipCode, JoinedDate, WorkHours, Department)
                             values (@Name, @Surname, @Birthdate, @Adress, @ZipCode, @JoinedDate, @WorkingHours, @Department)
                             ";

            string sqlDataSource = connectionString;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Name", oPersonnel.Name);
                    myCommand.Parameters.AddWithValue("@Surname", oPersonnel.Surname);
                    myCommand.Parameters.AddWithValue("@Birthdate", oPersonnel.Birthdate);
                    myCommand.Parameters.AddWithValue("@Adress", oPersonnel.Adress);
                    myCommand.Parameters.AddWithValue("@ZipCode", oPersonnel.ZipCode);
                    myCommand.Parameters.AddWithValue("@JoinedDate", oPersonnel.JoinedDate);
                    myCommand.Parameters.AddWithValue("@WorkingHours", oPersonnel.WorkingHours);
                    myCommand.Parameters.AddWithValue("@Department", oPersonnel.Department);
                    rows = myCommand.ExecuteNonQuery();

                }
            }
            return rows == 1;
        }

        public List<Personnel> GetAll()
        {
            List<Personnel> lst = null;
            string query = @"
                            select PersonnelId, Name, Surname, Birthdate, Adress, ZipCode, JoinedDate, WorkHours, Department
                            from dbo.Personnel";

            //string sqlDataSource = _config.GetConnectionString("PersonnelAppCon");
            string sqlDataSource = connectionString;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    if (myCommand != null)
                    {
                        lst = new List<Personnel>();
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            //Map registry to Personnel Object
                            int personnelId = Convert.ToInt32(myReader["PersonnelId"].ToString());
                            string name = myReader["Name"].ToString();
                            string surname = myReader["Surname"].ToString();
                            DateTime birthdate = DateTime.Parse(myReader["Birthdate"].ToString());
                            string adress = myReader["Adress"].ToString();
                            string zipCode = myReader["ZipCode"].ToString();
                            DateTime joinedDate = DateTime.Parse(myReader["JoinedDate"].ToString());
                            int workingHours = Convert.ToInt32(myReader["WorkHours"].ToString());
                            string department = myReader["Department"].ToString();

                            lst.Add(new Personnel(personnelId, name, surname, birthdate, adress, zipCode, joinedDate, workingHours, department));

                        }
                        myReader.Close();
                    }
                }
            }
            return lst;
        }

        public List<Salary> GetSalariesById(int id)
        {
            List<Salary> lst = new List<Salary>();
            string query = @"select * from dbo.Salary where PersonnelId = @PersonnelId";

            //string sqlDataSource = _config.GetConnectionString("PersonnelAppCon");
            string sqlDataSource = connectionString;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                SqlCommand myCommand = new SqlCommand(query, myConn);

                myCommand.Parameters.AddWithValue("@PersonnelId", id);
                myReader = myCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(myReader);
                myReader.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    //Map registry to Personnel Object
                    int salaryId = int.Parse(dr["SalaryId"].ToString());
                    double grossIncome = double.Parse(dr["GrossIncome"].ToString());
                    int month = int.Parse(dr["Month"].ToString());
                    int year = int.Parse(dr["Year"].ToString());
                    Salary salary = new Salary(salaryId, grossIncome, month, year);


                    SqlCommand myCommandChild = new SqlCommand("SELECT t.*,t2.TaxId, t2.Description, t2.Percentage, t2.TaxType FROM Salary_Item t, Tax t2 WHERE t.TaxId = t2.TaxId AND SalaryId = @SalaryId", myConn);

                    myCommandChild.Parameters.AddWithValue("@SalaryId", salaryId);
                    SqlDataReader myReaderChild = myCommandChild.ExecuteReader();
                    while (myReaderChild.Read())
                    {
                        int taxId = int.Parse(myReaderChild["TaxId"].ToString());
                        string description = myReaderChild["Description"].ToString();
                        int percentage = int.Parse(myReaderChild["Percentage"].ToString());
                        string taxType = myReaderChild["TaxType"].ToString();
                        Tax tax = new(taxId, description, percentage, taxType);
                        double amount = double.Parse(myReaderChild["Amount"].ToString());


                        SalaryItem salaryItem = new SalaryItem(tax, amount);
                        salary.Add(salaryItem);

                    }
                    myReaderChild.Close();


                    lst.Add(salary);
                    
                }
                myReader.Close();
            }
            return lst;

        }

        public bool Update(Personnel oPersonnel)
        {

            int rows = 0;
            string query = @"
                             UPDATE dbo.Personnel 
                             SET Name = @Name, Surname = @Surname , Birthdate = @Birthdate, Adress = @Adress
                                ,ZipCode = @ZipCode, JoinedDate = @JoinedDate , WorkHours = @WorkingHours, Department = @Department
                             WHERE PersonnelId = @PersonnelId ";

            string sqlDataSource = connectionString;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Name", oPersonnel.Name);
                    myCommand.Parameters.AddWithValue("@Surname", oPersonnel.Surname);
                    myCommand.Parameters.AddWithValue("@Birthdate", oPersonnel.Birthdate);
                    myCommand.Parameters.AddWithValue("@Adress", oPersonnel.Adress);
                    myCommand.Parameters.AddWithValue("@ZipCode", oPersonnel.ZipCode);
                    myCommand.Parameters.AddWithValue("@JoinedDate", oPersonnel.JoinedDate);
                    myCommand.Parameters.AddWithValue("@WorkingHours", oPersonnel.WorkingHours);
                    myCommand.Parameters.AddWithValue("@Department", oPersonnel.Department);
                    myCommand.Parameters.AddWithValue("@PersonnelId", oPersonnel.PersonnelId);
                    rows = myCommand.ExecuteNonQuery();

                }
            }
            return rows == 1;
        }
        public bool Delete (int id)
        {
            int rows = 0;
            string query = @"
                             DELETE FROM dbo.Personnel WHERE personnelId = @personnelId";

            string sqlDataSource = connectionString;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.Clear();
                    myCommand.Parameters.AddWithValue("@personnelId", id);
                    rows = myCommand.ExecuteNonQuery();

                }
            }
            return rows == 1;
        }
    }
}
