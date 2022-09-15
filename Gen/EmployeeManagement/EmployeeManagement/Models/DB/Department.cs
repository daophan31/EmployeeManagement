using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.DB
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public ICollection<Employee> Employees;
    }
}
