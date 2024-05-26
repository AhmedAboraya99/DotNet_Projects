using System.Net.Http.Json;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages;

public partial class EmployeeDetails
{
    [Parameter]
    public int EmployeeId { get; set; }

    public EmployeeOverview.Employee CurrentEmployee { get; set; } = new EmployeeOverview.Employee();
    /*Way one two inject Http client:
     [Inject]
    public HttpClient HttpClient { get; set; } */
    [Inject]
    public IEmployeeDataService EmployeeDataService{get; set; }

    protected override async Task OnInitializedAsync()
    {



        //Way1:// CurrentEmployee = EmployeeData.Employees.FirstOrDefault(e => e.EmployeeId == EmpId);
        //Way2 Api httpclient:
        /* CurrentEmployee = await HttpClient.GetFromJsonAsync<Employee>("http://localhost:5103/api/Employee"+EmpId); */
        
        CurrentEmployee = await EmployeeDataService.GetEmployeeByID(EmployeeId);
}
    

}