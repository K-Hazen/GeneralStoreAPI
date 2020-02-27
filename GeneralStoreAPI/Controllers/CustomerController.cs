using GeneralStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class CustomerController : ApiController
    {
        //in this section we are building out controller end points

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //POST

        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if(customer == null) //the null breaks the model state which is a different error than what the next if statement would return 
            {
                return BadRequest("Request body was empty. Please provide a model");
            }

            //why can we access model state --> because if comes from API controller which we inherit from ApiController. This if statement below returns a good model state but with and error saying... hey we are missing required info 

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }
            _context.Customers.Add(customer);  //accessing DbSet --> .Add is adding it to our table... Dbcontext helps us shuffle it to database 

            await _context.SaveChangesAsync(); //saves awaits the adding to the Dbcontext/database 

            return Ok();
        }

        //GET All

        public async Task<IHttpActionResult> GetAll()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();

            return Ok(customers); 

            // return Ok(await _context.Customers.ToListAsync());  --> functionally same as the above code  
        }

        //GET by ID

        public async Task<IHttpActionResult> GetById(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id); // creating a local variable 

            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound(); 
        }
    }
}
