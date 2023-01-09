using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Test2.Models;

namespace Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Employee> GetEmployee()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("TestDB").ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * FROM [Test].[dbo].[Employee]", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> list = new List<Employee>();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    emp.Email = Convert.ToString(dt.Rows[i]["email"]);
                    emp.IsActive = Convert.ToDecimal(dt.Rows[i]["isActive"]);
                    emp.Name = Convert.ToString(dt.Rows[i]["name"]);
                    emp.Phone = Convert.ToString(dt.Rows[i]["phone"]);
                    emp.Position = Convert.ToString(dt.Rows[i]["position"]);
                    emp.Salary = Convert.ToDecimal(dt.Rows[i]["salary"]);
                    list.Add(emp);
                }
            }

            return list;
        }

        [HttpGet]
        [Route("GetById")]
        public Employee GetEmployeeById(string id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("TestDB").ToString());
            SqlDataAdapter da = new SqlDataAdapter(string.Format("SELECT * FROM [Test].[dbo].[Employee] WHERE ID = '{0}'", id), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Employee emp = new Employee();
            emp.Id = Convert.ToInt32(dt.Rows[0]["id"]);
            emp.Email = Convert.ToString(dt.Rows[0]["email"]);
            emp.IsActive = Convert.ToDecimal(dt.Rows[0]["isActive"]);
            emp.Name = Convert.ToString(dt.Rows[0]["name"]);
            emp.Phone = Convert.ToString(dt.Rows[0]["phone"]);
            emp.Position = Convert.ToString(dt.Rows[0]["position"]);
            emp.Salary = Convert.ToDecimal(dt.Rows[0]["salary"]);
            return emp;
        }
    }
}
