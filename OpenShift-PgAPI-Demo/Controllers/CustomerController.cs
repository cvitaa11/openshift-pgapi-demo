using Microsoft.AspNetCore.Mvc;
using OpenShift_PgAPI_Demo.Models;

namespace OpenShift_PgAPI_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {     

        private readonly sampledbContext _context;

        public CustomerController(sampledbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetCustomers")]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }
    }
}