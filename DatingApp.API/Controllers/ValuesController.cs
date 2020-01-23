using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext context;

        public ValuesController(DataContext context)
        {
            this.context = context;
        }
        //GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues(){
            var values = await context.Values.ToListAsync();
            return Ok(values);
        }
        //GET api/value/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValuesById(int id){
            var value = await context.Values.FirstOrDefaultAsync(x => x.Id == id); //returning first or default value of the values
            return Ok(value);
        }
    }
}