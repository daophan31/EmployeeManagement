using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class EmployeeManagementContext : IdentityDbContext
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeManagement.Models.DB.Department> Department { get; set; } = default!;

        public DbSet<EmployeeManagement.Models.DB.Employee>? Employee { get; set; }

        public DbSet<EmployeeManagement.Models.DB.TimeSheet>? TimeSheet { get; set; }
    }
}
