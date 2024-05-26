using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WASMWebAPI.Models;
using WASMWebAPI.Pages;

namespace WASMWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;
        public CountryController(EmployeeDbContext cntryDbContext)
        {
            this._dbContext = cntryDbContext;
        }
        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<EmployeeOverview.Country> Get()
        {

            return _dbContext.Countries.ToList();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public EmployeeOverview.Country Get(int id)
        {
            return _dbContext.Countries.FirstOrDefault(emp => emp.CountryId == id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] EmployeeOverview.Country cntry)
        {
            _dbContext.Countries.Add(cntry);
            _dbContext.SaveChanges();
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeOverview.Country cntry)
        {
            var employeeInDb = _dbContext.Countries.SingleOrDefault(c => c.CountryId == id);
            
            if(employeeInDb == null)
                throw new HttpRequestException((HttpRequestError)HttpStatusCode.NotFound);
            employeeInDb.CountryId = cntry.CountryId;
            employeeInDb.CountryName = cntry.CountryName;
            
            _dbContext.SaveChanges();
            
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeeInDb = _dbContext.Countries.SingleOrDefault(c => c.CountryId == id);
            _dbContext.Remove(employeeInDb);
            _dbContext.SaveChanges();

        }
    }
}
