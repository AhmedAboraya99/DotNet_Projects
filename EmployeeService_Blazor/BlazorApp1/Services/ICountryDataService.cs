using BlazorApp1.Pages;

namespace BlazorApp1.Services;

public interface ICountryDataService
{
    Task<List<EmployeeOverview.Country>> GetCountries();
    Task<EmployeeOverview.Country> GetCountryByID(int CntryID);
    Task AddCountry(EmployeeOverview.Country cntry);
    Task RemoveCountry(int CntryID);
    Task UpdateCountry(EmployeeOverview.Country cntry);
}