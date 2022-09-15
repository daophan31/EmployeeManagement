using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.DB
{
    public class TimeSheet
    {
        [Key]
        public int TimeSheetID { get; set; }
        public DateTime date { get; set; }
        public Employee Employee;
        public string? Status { get; set; }
    }
}
