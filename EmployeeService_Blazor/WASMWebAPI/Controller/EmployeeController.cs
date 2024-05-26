using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WASMWebAPI.Models;
using WASMWebAPI.Pages;

namespace WASMWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeController(EmployeeDbContext EmpDbContext)
        {
            this._dbContext = EmpDbContext;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<EmployeeOverview.Employee> Get()
        {

            return _dbContext.Employees.ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeOverview.Employee Get(int id)
        {
            return _dbContext.Employees.FirstOrDefault(emp => emp.EmployeeId == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] EmployeeOverview.Employee Emp)
        {
            _dbContext.Employees.Add(Emp);
            _dbContext.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeOverview.Employee Emp)
        {
            var employeeInDb = _dbContext.Employees.SingleOrDefault(c => c.EmployeeId == id);
            
            if(employeeInDb == null)
                throw new HttpRequestException((HttpRequestError)HttpStatusCode.NotFound);
            employeeInDb.FirstName = Emp.FirstName;
            employeeInDb.LastName = Emp.LastName;
            employeeInDb.Gender = Emp.Gender;

            _dbContext.SaveChanges();
            
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeeInDb = _dbContext.Employees.SingleOrDefault(c => c.EmployeeId == id);
            _dbContext.Remove(employeeInDb);
            _dbContext.SaveChanges();

        }
    }
}
