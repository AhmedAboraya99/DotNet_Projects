using System.Net.Http.Json;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using static BlazorApp1.Pages.EmployeeOverview;

namespace BlazorApp1.Pages;

public partial class EmployeeEdit
{
    [Parameter]
    public int EmpId { get; set; }

    public Employee CurrentEmployee { get; set; } = new Employee();
    public List<Country> Countries { get; set; }  = new List<Country>();
    /*Way one two inject Http client:
     [Inject]
    public HttpClient HttpClient { get; set; } */
    [Inject]
    public IEmployeeDataService EmployeeDataService{get; set; }
    [Inject]
    public ICountryDataService CountryDataService{get; set; }

    
    protected bool Saved;
    
    protected override async Task OnInitializedAsync()
    {

        //Way1:// CurrentEmployee = EmployeeData.Employees.FirstOrDefault(e => e.EmployeeId == EmpId);
        //Way2 Api httpclient:
        /* CurrentEmployee = await HttpClient.GetFromJsonAsync<Employee>("http://localhost:5103/api/Employee"+EmpId);
        Countries = await HttpClient.GetFromJsonAsync<List<Country>>("http://localhost:5103/api/Country"); */
        
        CurrentEmployee = await EmployeeDataService.GetEmployeeByID(EmpId);
        Countries = await CountryDataService.GetCountries();
    }
    
    

    private void HandleInvalidSubmit()
    {
        throw new NotImplementedException();
    }

    private void HandleValidSubmit()
    {
        Saved = false;
        if (CurrentEmployee.EmployeeId == 0)
        {
            EmployeeDataService.AddEmployee(CurrentEmployee);
        }
        else
        {
            EmployeeDataService.UpdateEmployee(CurrentEmployee);
            
            //Way1 "without json api formatting": 
            /*var EditEmp = EmployeeData.Employees.FirstOrDefault((e) => e.EmployeeId == EmpId);
            EditEmp.FirstName = CurrentEmployee.FirstName;
            EditEmp.LastName = CurrentEmployee.LastName;
            EditEmp.Gender = CurrentEmployee.Gender;*/

            Saved = true;
        }
    }
}