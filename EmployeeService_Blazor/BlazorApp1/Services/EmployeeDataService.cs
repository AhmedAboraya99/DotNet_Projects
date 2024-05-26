using System.Text;
using System.Text.Json;
using BlazorApp1.Pages;

namespace BlazorApp1.Services;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly HttpClient _httpClient;

    public EmployeeDataService(HttpClient httpClient)
    {
        this._httpClient = httpClient;

    }
    public async Task<IEnumerable<EmployeeOverview.Employee>?> GetEmployees()
    {
       return await JsonSerializer.DeserializeAsync<IEnumerable<EmployeeOverview.Employee>>
       (await _httpClient.GetStreamAsync("/api/Employee")
           , new JsonSerializerOptions(){PropertyNameCaseInsensitive = true}) ;
    }

    public async Task<EmployeeOverview.Employee> GetEmployeeByID(int EmpID)
    {
        return await JsonSerializer.DeserializeAsync<EmployeeOverview.Employee>
        (await _httpClient.GetStreamAsync("/api/Employee/"+EmpID)
            , new JsonSerializerOptions(){PropertyNameCaseInsensitive = true}) ;

    }

    public async Task AddEmployee(object emp)
    {
        var EmpObjSerialize = new  StringContent(JsonSerializer.Serialize(emp), Encoding.UTF8, "application/json");
        await _httpClient.PostAsync("/api/Employee", EmpObjSerialize);
    }

    public async Task RemoveEmployee(int EmpID)
    {
        await _httpClient.DeleteAsync("/api/Employee/"+EmpID);

    }

    public async Task UpdateEmployee(EmployeeOverview.Employee emp)
    {
        var EmpObjSerialize = new  StringContent(JsonSerializer.Serialize(emp), Encoding.UTF8, "application/json");
        await _httpClient.PutAsync("/api/Employee/"+emp.EmployeeId, EmpObjSerialize);

    }
}