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
    public class ProductController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        //POST

        public async Task<IHttpActionResult> Post(Product product)
        {
            if (product == null)
            {
                return BadRequest("Request body was empty.");
            }

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //GET all

        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        //GET By ID

        public async Task<IHttpActionResult> GetById(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound(); 
        }
    }
}
