using Microsoft.EntityFrameworkCore;
using WASMWebAPI.Pages;

namespace WASMWebAPI.Models;

public class EmployeeDbContext:DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
    {
        
    }
    public virtual DbSet<EmployeeOverview.Employee> Employees { get; set; }
    
    public DbSet<EmployeeOverview.Country>  Countries { get; set; }
     
}