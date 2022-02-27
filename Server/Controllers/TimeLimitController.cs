using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TogglTimeWeb.Server.Data;
using TogglTimeWeb.Shared;

namespace TogglTimeWeb.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeLimitController : ControllerBase
{
    private readonly TogglTimeContext _context;

    public TimeLimitController(TogglTimeContext ctx)
    {
        this._context = ctx;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var timeLimits = await _context.TimeLimits.ToListAsync();
        return Ok(timeLimits);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var timeLimit = await _context.TimeLimits.FirstOrDefaultAsync(x => x.TimeLimitID == id);
        return Ok(timeLimit);
    }


    [HttpPost]
    public async Task<IActionResult> Post(TimeLimit timeLimit)
    {
        _context.Add(timeLimit);
        await _context.SaveChangesAsync();
        return Ok(timeLimit.TimeLimitID);
    }

    [HttpPut]
    public async Task<IActionResult> Put(TimeLimit timeLimit)
    {
        _context.Entry(timeLimit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var dev = new TimeLimit(){ TimeLimitID= id };
        _context.Remove(dev);
        await _context.SaveChangesAsync();
        return NoContent();
    }



}