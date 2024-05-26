using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages;

public partial class EmployeeOverview
{
    public enum MaritalStatus { Married, Single, Other}

    public enum Gender {Male, Female}
    public class Employee
    {

        public DateTime? BirthDate;
        public int PhoneNumber;
        
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }


        public string Comment { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public int CountryId { get; set; }
    }

    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }


    private void InitializeCountries()
    {
        Countries = new List<Country>
        {
            new Country { CountryId = 1, CountryName = "Egypt" },
            new Country { CountryId = 2, CountryName = "USA" },
            new Country { CountryId = 3, CountryName = "Sudan" },
            new Country { CountryId = 4, CountryName = "Iraq" },
            new Country { CountryId = 5, CountryName = "Libya" },
            new Country { CountryId = 6, CountryName = "Palestine" },
            new Country { CountryId = 7, CountryName = "South Africa" },
            new Country { CountryId = 8, CountryName = "Jordon" }

        };
    }

    private void InitializeEmployees()
    {
        Employees = new List<BlazorApp1.Pages.EmployeeOverview.Employee>()
        {
            new BlazorApp1.Pages.EmployeeOverview.Employee{EmployeeId = 1, FirstName = "Yara", LastName = "Hamdy", MaritalStatus = MaritalStatus.Single, Gender = Gender.Female, JoinedDate = new DateTime(2010, 4, 6), Comment = "Senior Employee", ExitDate = null},
            new BlazorApp1.Pages.EmployeeOverview.Employee{EmployeeId = 2, FirstName = "Ahmed", LastName = "Fawzy", MaritalStatus = MaritalStatus.Married, Gender = Gender.Male, JoinedDate = new DateTime(2019, 2, 7)}
            
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}