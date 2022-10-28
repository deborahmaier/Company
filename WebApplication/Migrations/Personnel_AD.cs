using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication.Models;
using Chilkat;

namespace WebApplication.Migrations
{
    public class Personnel_AD
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Personnel_AD(IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _webHostEnvironment = webHostEnvironment;
        }

       

        [HttpPost]
        public JsonResult Post(Personnel per)
        {
            string query = @"
                             insert into dbo.Personnel 
                             (Name, Surname, Birthdate, Adress, ZipCode, JoinedDate, WorkHours, Department)
                             values (@Name, @Surname, @Birthdate, @Adress, @ZipCode, @JoinedDate, @WorkHours, @GrossIncome, @Department)";

            DataTable dt = new DataTable();
            string sqlDataSource = _config.GetConnectionString("PersonnelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Name", per.Name);
                    myCommand.Parameters.AddWithValue("@Surname", per.Surname);
                    myCommand.Parameters.AddWithValue("@Birthdate", per.Birthdate);
                    myCommand.Parameters.AddWithValue("@Adress", per.Adress);
                    myCommand.Parameters.AddWithValue("@ZipCode", per.ZipCode);
                    myCommand.Parameters.AddWithValue("@JoinedDate", per.JoinedDate);
                    myCommand.Parameters.AddWithValue("@WorkHours", per.WorkingHours);
                    myCommand.Parameters.AddWithValue("@Department", per.Department);
                    myReader = myCommand.ExecuteReader();
                    dt.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Personnel per)
        {
            string query = @"
                           update dbo.Personnel
                           set Name=@Name, Surname=@Surname, Birthdate=@Birthdate, Adress=@Adress, ZipCode=@ZipCode, 
                           JoinedDate=@JoinedDate, WorkHours=@WorkHours,
                           Department=@Department                           
                           where PersonnelId=@PersonnelId";

            DataTable dt = new DataTable();
            string sqlDataSource = _config.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@PersonnelId", per.PersonnelId);
                    myCommand.Parameters.AddWithValue("@Surname", per.Surname);
                    myCommand.Parameters.AddWithValue("@Birthdate", per.Birthdate);
                    myCommand.Parameters.AddWithValue("@Adress", per.Adress);
                    myCommand.Parameters.AddWithValue("@ZipCode", per.ZipCode);
                    myCommand.Parameters.AddWithValue("@JoinedDate", per.JoinedDate);
                    myCommand.Parameters.AddWithValue("@WorkHours", per.WorkingHours);
                    myCommand.Parameters.AddWithValue("@Department", per.Department);
                    myReader = myCommand.ExecuteReader();
                    dt.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{PersonnelId}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.Personnel
                            where PersonnelId=@PersonnelId
                            ";

            DataTable dt = new DataTable();
            string sqlDataSource = _config.GetConnectionString("PersonnelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@PersonnelId", id);

                    myReader = myCommand.ExecuteReader();
                    dt.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }

}
