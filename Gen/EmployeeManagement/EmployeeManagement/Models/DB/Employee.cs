using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.DB
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public Double BaseSalary { get; set; }

        public Department Department;

        public ICollection<TimeSheet> TimeSheets;
    }
}
