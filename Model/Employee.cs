using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Employee class to strcture the Employee Details
    /// </summary>
    public class Employee
    {        
        /// <summary>
        /// Employee --> Name of Employee
        /// </summary>
        public string? employeeName { get; set; }

        /// <summary>
        /// Employee --> ID of Employee
        /// </summary>
        public int employeeId { get; set; }

        /// <summary>
        /// Employee --> Date of Joining of the Employee
        /// </summary>
        public string? employeeDoJ { get; set; }

        /// <summary>
        /// Employee --> Current Project Employee's working on
        /// </summary>
        public string? employeeCurrentProject { get; set; }

        
    }
}
