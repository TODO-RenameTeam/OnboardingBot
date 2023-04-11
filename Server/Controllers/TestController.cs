using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public TestController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<TestViewModel>>> GetAll()
    {
        var res = Context.Tests.ToList();

        return res.Select(x => Mapper.Map<TestViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TestViewModel>> GetByID(Guid id)
    {
        var test = Context.Tests.Include(x => x.Buttons)
            .Include(x => x.Questions)
            .FirstOrDefault(x => x.ID == id);

        if (test == null)
        {
            return NotFound();
        }

        return Mapper.Map<TestViewModel>(test);
    }

    [HttpPost]
    public async Task<ActionResult<TestViewModel>> Create(TestEditModel test)
    {
        var entity = Mapper.Map<TestEntity>(test);

        Context.Tests.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<TestViewModel>> Update(Guid id, TestEditModel test)
    {
        var entity = Mapper.Map<TestEntity>(test);
        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
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