using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Text.RegularExpressions;

// Scaffold - DbContext "Server=BRD-3917L13-L\SQLEXPRESS;Database=Organization;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir DBModels - f

//    Scaffold - DbContext "connection-string" MySql.EntityFrameworkCore - OutputDir sakila - f

// Scaffold-DbContext "Server=BRD-3917L13-L\SQLEXPRESS;Database=Organization;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir DBModels - Tables "Employee" - f

// Scaffold-DbContext "Server=BRD-3917L13-L\SQLEXPRESS;Database=Organization;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModels

namespace WebAPI.Controllers
{
    /// <summary>
    /// Performing the basic CRUD Operations using Web API
    /// </summary>
    [ApiController]
    [Route("CRUD Operations")]
    public class CRUD_OperationController : ControllerBase
    {
        /*public IActionResult Index()
        {
            return Ok();
        }*/



        /// <summary>
        /// Fetching the Employee Details using GET() method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        
        [HttpGet("Fetch Employee Details")]
        public string FetchEmployeeDetails()
        {
            //employee.employeeCurrentProject = "";
            return "PASS";
        }

        /// <summary>
        /// Creating a new Employee using POST() method
        /// </summary>
        /// <param name="employee">Object to store the employee details</param>
        /// <returns></returns>
        [HttpPost("Add Employee Details")]
        public Employee AddEmployeeDetails(Employee employee)
        {
            employee.employeeName = "Aryan";
            employee.employeeDoJ = "October 3rd, 2022";
            employee.employeeId = 1400;
            employee.employeeCurrentProject = "None";

            return employee;
        }

        /// <summary>
        /// Updating the Employee Details using PUT() method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("Update Employee Details")]
        public Employee UpdateEmployeeDetails(Employee employee)
        {
            employee.employeeName = "Aryan Gupta";

            return employee;
        }

        
        /// <summary>
        /// Deleting an Employee using DELETE() method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpDelete("Remove Employee Details")]
        public Employee RemoveEmployeeDetails(Employee employee)
        {
            employee.employeeName = "Aryan";
            employee.employeeDoJ = "October 3rd, 2022";
            employee.employeeId = 1400;

            return employee;
        }
    }
}
