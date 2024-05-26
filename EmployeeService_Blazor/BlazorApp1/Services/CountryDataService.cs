using System.Text;
using System.Text.Json;
using BlazorApp1.Pages;

namespace BlazorApp1.Services;

public class CountryDataService: ICountryDataService
{
    private readonly HttpClient _httpClient;

    public CountryDataService(HttpClient httpClient)
    {
        this._httpClient = httpClient;

    }
    public async Task<List<EmployeeOverview.Country>?> GetCountries()
    {
        return await JsonSerializer.DeserializeAsync<List<EmployeeOverview.Country>>
        (await _httpClient.GetStreamAsync("/api/Country")
            , new JsonSerializerOptions(){PropertyNameCaseInsensitive = true}) ;
    }

    public async Task<EmployeeOverview.Country> GetCountryByID(int EmpID)
    {
        return await JsonSerializer.DeserializeAsync<EmployeeOverview.Country>
        (await _httpClient.GetStreamAsync("/api/Country/"+EmpID)
            , new JsonSerializerOptions(){PropertyNameCaseInsensitive = true}) ;

    }

    public async Task AddCountry(EmployeeOverview.Country cntry)
    {
        var EmpObjSerialize = new  StringContent(JsonSerializer.Serialize(cntry), Encoding.UTF8, "application/json");
        await _httpClient.PostAsync("/api/Country", EmpObjSerialize);
    }

    public async Task RemoveCountry(int EmpID)
    {
        await _httpClient.DeleteAsync("/api/Country/"+EmpID);

    }

    public async Task UpdateCountry(EmployeeOverview.Country emp)
    {
        var EmpObjSerialize = new  StringContent(JsonSerializer.Serialize(emp), Encoding.UTF8, "application/json");
        await _httpClient.PutAsync("/api/Country/"+emp.CountryId, EmpObjSerialize);

    }
}