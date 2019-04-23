using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using VueValidation.Data;

namespace VueValidation.Controllers
{
  [Route("/api/customers")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private readonly CustomerContext _ctx;
    private readonly LinkGenerator _generator;

    public CustomersController(CustomerContext ctx, LinkGenerator generator)
    {
      _ctx = ctx;
      _generator = generator;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
      try
      {
        var results = await _ctx.Customers.ToArrayAsync();

        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    [HttpGet("{id:int}", Name = "GetCustomer")]
    public async Task<IActionResult> Get(int id)
    {
      var result = await _ctx.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
      if (result == null) return NotFound();

      return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> Post(Customer model)
    {
      try
      {
        await _ctx.AddAsync(model);
        if (await _ctx.SaveChangesAsync() > 0)
        { 
          var url = _generator.GetPathByRouteValues("GetCustomer", new { id = model.Id });
          return Created(url, model);
        }
        else
        {
          return BadRequest("Failed to create customer");
        }
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}
