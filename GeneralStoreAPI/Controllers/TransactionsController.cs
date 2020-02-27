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
    public class TransactionsController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        //POST
        
        public async Task<IHttpActionResult> Post(Transaction transaction)
        {
            if (transaction == null)
                return BadRequest("The request was empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //What we need to do is check customer ID and product ID to make sure they are valid (exist) or will kick an error
            //feed back comes from the "save changes" function
            //need to check database to see if product and customer exist

            Customer customer = await _context.Customers.FindAsync(transaction.CustomerId); //saying hey, database... is this customer there? To check see if null
            if (customer == null)
                return BadRequest("Invalid CustomerId. No customer by that ID.");

            //Repeat for product 

            Product product = await _context.Products.FindAsync(transaction.ProductId);
            if (product == null)
                return BadRequest("Invalid ProductId. No product by that ID.");

            //creating date of right now... thinking this is at the time of check out 

            transaction.DateOfTransaction = DateTime.Now; 

            _context.Transactions.Add(transaction);     //add is not an async method 

            await _context.SaveChangesAsync();
            return Ok(); 
        }

        //GET All

        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _context.Transactions.ToListAsync());
        }

        //breakpoint through 
    }
}
