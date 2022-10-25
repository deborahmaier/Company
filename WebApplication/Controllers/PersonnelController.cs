using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplication.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonnelController(IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _webHostEnvironment = webHostEnvironment;
        }

        public PersonnelController()
        {
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select PersonnelId, Name, Surname, Birthdate, Adress, ZipCode, JoinedDate, WorkingHours,GrossIncome, Department
                            from dbo.Employee";
            DataTable dt = new DataTable();
            string sqlDataSource = _config.GetConnectionString("PersonnelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query,myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    dt.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(dt);
        }
        
        [HttpPost]
        public JsonResult Post(Personnel per)
        {
            string query = @"
                             insert into dbo.Personnel 
                             (Name, Surname, Birthdate, Adress, ZipCode, JoinedDate, WorkingHours,GrossIncome, Department)
                             values (@Name, @Surname, @Birthdate, @Adress, @ZipCode, @JoinedDate, @WorkingHours, @GrossIncome, @Department)";
            
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
                    myCommand.Parameters.AddWithValue("@WorkingHours", per.WorkingHours);
                    myCommand.Parameters.AddWithValue("@GrossIncome", per.GrossIncome);
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
                           JoinedDate=@JoinedDate, WorkingHours=@WorkingHours,
                           GrossIncome=@GrossIncome, Department=@Department                           
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
                    myCommand.Parameters.AddWithValue("@WorkingHours", per.WorkingHours);
                    myCommand.Parameters.AddWithValue("@GrossIncome", per.GrossIncome);
                    myCommand.Parameters.AddWithValue("@Department", per.Department);
                    myReader = myCommand.ExecuteReader();
                    dt.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        
        [HttpDelete("{id}")]
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
