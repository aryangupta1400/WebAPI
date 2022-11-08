using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("CRUD Operations")]
    public class CRUD_OperationController : ControllerBase
    {
        /*public IActionResult Index()
        {
            return Ok();
        }*/

        [HttpGet("Fetch Employee Details")]
        public Employee FetchEmployeeDetails(Employee employee)
        {
            employee.employeeCurrentProject = "";
            return employee;
        }

        [HttpPost("Add Employee Details")]
        public Employee AddEmployeeDetails(Employee employee)
        {
            employee.employeeName = "Aryan";
            employee.employeeDoJ = "October 3rd, 2022";
            employee.employeeId = 1400;
            employee.employeeCurrentProject = "None";

            return employee;
        }

        [HttpPut("Update Employee Details")]
        public Employee UpdateEmployeeDetails(Employee employee)
        {
            employee.employeeName = "Aryan Gupta";

            return employee;
        }

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
