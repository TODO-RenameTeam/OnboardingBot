using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Shared.Entities;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private DBContext Context;

    public TestController(DBContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<TestEntity>>> GetAll()
    {
        return Context.Tests.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TestEntity>> GetByID(Guid id)
    {
        var test = Context.Tests.Include(x => x.ButtonsBefore)
            .Include(x => x.ButtonsAter)
            .Include(x => x.Questions)
            .FirstOrDefault(x => x.ID == id);
        
        if (test == null)
        {
            return NotFound();
        }

        return test;
    }

    [HttpPost]
    public async Task<ActionResult<TestEntity>> Create(TestEntity test)
    {
        Context.Tests.Add(test);
        await Context.SaveChangesAsync();

        return await GetByID(test.ID);
    }

    [HttpPut]
    public async Task<ActionResult<TestEntity>> Update(Guid id, TestEntity test)
    {
        test.ID = id;

        Context.Attach(test);
        Context.Entry(test).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(test.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var test = await Context.Tests.FindAsync(id);
        if (test == null)
        {
            return NotFound();
        }

        Context.Tests.Remove(test);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}