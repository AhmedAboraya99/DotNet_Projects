using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using static BlazorApp1.Pages.EmployeeOverview;

namespace BlazorApp1.Pages;

public partial class AddEmployee
{
    [Parameter]
    public int EmpId { get; set; }
    
    public Employee NewEmployee { get; set; } = new Employee();
    public List<Country> Countries{ get; set; } = new List<Country>();
    [Inject]
    public IEmployeeDataService EmployeeDataService { get; set; }
    [Inject]
    public ICountryDataService CountryDataService{get; set; }
    
    protected bool Saved;
    protected override async Task OnInitializedAsync()
    {

        Countries = await CountryDataService.GetCountries();
        
    }
    
    
    private void HandleInvalidSubmit()
    {
        throw new NotImplementedException();
    }

    private void HandleValidSubmit()
    {
        Saved = false;
        /* way1 :
         EmployeeData.Employees.Append(NewEmployee);
        // Clear the form for a new entry (optional)
        NewEmployee = new Employee();   */
        EmployeeDataService.AddEmployee(NewEmployee);
        Saved = true;
    }
}