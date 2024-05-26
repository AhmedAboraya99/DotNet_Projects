using BlazorApp1.Pages;

namespace BlazorApp1.Services;

public interface IEmployeeDataService
{
    Task<IEnumerable<EmployeeOverview.Employee>?> GetEmployees();
    Task<EmployeeOverview.Employee> GetEmployeeByID(int EmpID);
    Task AddEmployee(object emp);
    Task RemoveEmployee(int EmpID);
    Task UpdateEmployee(EmployeeOverview.Employee emp);
}