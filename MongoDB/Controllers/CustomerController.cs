using Microsoft.AspNetCore.Mvc;
using MongoDB.Data;
using MongoDB.Data.Entities;
using MongoDB.Driver;

namespace MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IMongoCollection<Customer> _customers;
        
        public CustomerController(MongoDbService mongoDbService) 
        {
            _customers = mongoDbService.Database?.GetCollection<Customer>("customer");
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customers.Find(FilterDefinition<Customer>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer?>> GetById(string id)
        {

            var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
            var customer = _customers.Find(filter).FirstOrDefault();

            return customer is not null ? Ok(customer) : NotFound();

        }

    }
}
