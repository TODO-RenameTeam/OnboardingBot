using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public PositionController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<PositionViewModel>>> GetAll()
    {
        var res = Context.Positions.ToList();

        return res.Select(x => Mapper.Map<PositionViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PositionViewModel>> GetByID(Guid id)
    {
        var position = Context.Positions.Include(x => x.MainUser)
            .FirstOrDefault(x => x.ID == id);

        if (position == null)
        {
            return NotFound();
        }

        return Mapper.Map<PositionViewModel>(position);
    }

    [HttpPost]
    public async Task<ActionResult<PositionViewModel>> Create(PositionEditModel position)
    {
        var entity = Mapper.Map<PositionEntity>(position);

        Context.Positions.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<PositionViewModel>> Update(Guid id, PositionEntity position)
    {
        var entity = Mapper.Map<PositionEntity>(position);

        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var position = await Context.Positions.FindAsync(id);
        if (position == null)
        {
            return NotFound();
        }

        Context.Positions.Remove(position);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}