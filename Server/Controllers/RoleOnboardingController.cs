using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleOnboardingController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public RoleOnboardingController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoleOnboardingViewModel>>> GetAll()
    {
        var res = Context.RoleOnboardings
            .Include(x => x.Position)
            .Include(x => x.UserSteps)
            .Include(x => x.Steps)
            .Include(x => x.StepPositions)
            .ToList();

        return res.Select(x => Mapper.Map<RoleOnboardingViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleOnboardingViewModel>> GetByID(Guid id)
    {
        var roleOnboarding = Context.RoleOnboardings
            .Include(x => x.Position)
            .Include(x => x.UserSteps)
            .Include(x => x.Steps)
            .Include(x => x.StepPositions)
            .FirstOrDefault(x => x.ID == id);

        if (roleOnboarding == null)
        {
            return NotFound();
        }

        return Mapper.Map<RoleOnboardingViewModel>(roleOnboarding);
    }

    [HttpPost]
    public async Task<ActionResult<RoleOnboardingViewModel>> Create(RoleOnboardingEditModel roleOnboarding)
    {
        var entity = Mapper.Map<RoleOnboardingEntity>(roleOnboarding);

        var position = await Context.Positions.FindAsync(roleOnboarding.PositionID);
        if (position == null)
        {
            return BadRequest();
        }

        entity.UserSteps.Clear();
        entity.StepPositions.Clear();
        entity.Steps.Clear();

        Context.RoleOnboardings.Add(entity);
        await Context.SaveChangesAsync();

        foreach (var roleOnboardingStepViewModel in roleOnboarding.StepPositions)
        {
            var step = await Context.Steps.FindAsync(roleOnboardingStepViewModel.StepID);
            if (step != null)
            {
                entity.StepPositions.Add(new()
                {
                    StepID = step.ID,
                    Step = step,
                    Position = roleOnboardingStepViewModel.Position
                });
            }
        }

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<RoleOnboardingViewModel>> Update(Guid id, RoleOnboardingEntity roleOnboarding)
    {
        var entity = Mapper.Map<RoleOnboardingEntity>(roleOnboarding);
        entity.UserSteps.Clear();
        entity.StepPositions.Clear();
        entity.Steps.Clear();

        var position = Context.Positions.FirstOrDefault(x => x.ID == roleOnboarding.PositionID);
        if (position == null)
        {
            return BadRequest();
        }

        entity.Position = position;

        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        entity = Context.RoleOnboardings
            .Include(x => x.StepPositions)
            .Include(x => x.Steps)
            .FirstOrDefault(x => x.ID == id)!;
        entity.StepPositions.Clear();
        entity.Steps.Clear();

        await Context.SaveChangesAsync();

        foreach (var roleOnboardingStepViewModel in roleOnboarding.StepPositions)
        {
            var step = await Context.Steps.FindAsync(roleOnboardingStepViewModel.StepID);
            if (step != null)
            {
                entity.StepPositions.Add(new()
                {
                    StepID = step.ID,
                    Step = step,
                    Position = roleOnboardingStepViewModel.Position,
                    RoleOnboardingID = entity.ID
                });
            }
        }
        
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var roleOnboarding = await Context.RoleOnboardings.FindAsync(id);
        if (roleOnboarding == null)
        {
            return NotFound();
        }

        Context.RoleOnboardings.Remove(roleOnboarding);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}