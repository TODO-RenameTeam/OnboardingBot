using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StepController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public StepController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<StepViewModel>>> GetAll()
    {
        var res = Context.Steps.ToList();

        return res.Select(x => Mapper.Map<StepViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StepViewModel>> GetByID(Guid id)
    {
        var step = Context.Steps.Include(x => x.Position)
            .Include(x=>x.Quizes)
            .FirstOrDefault(x => x.ID == id);

        if (step == null)
        {
            return NotFound();
        }

        return Mapper.Map<StepViewModel>(step);
    }

    [HttpPost]
    public async Task<ActionResult<StepViewModel>> Create(StepEditModel step)
    {
        var entity = Mapper.Map<StepEntity>(step);
        entity.Quizes.Clear();

        Context.Steps.Add(entity);
        await Context.SaveChangesAsync();
        
        foreach (var quizViewModel in step.Quizes)
        {
            var quiz = await Context.Quizes.FindAsync(quizViewModel.ID);
            if (quiz != null)
            {
                entity.Quizes.Add(quiz);
            }
        }

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<StepViewModel>> Update(Guid id, StepEntity step)
    {
        var entity = Mapper.Map<StepEntity>(step);

        entity.ID = id;
        entity.Quizes.Clear();

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();
        
        foreach (var quizViewModel in step.Quizes)
        {
            var quiz = await Context.Quizes.FindAsync(quizViewModel.ID);
            if (quiz != null)
            {
                entity.Quizes.Add(quiz);
            }
        }

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var step = await Context.Steps.FindAsync(id);
        if (step == null)
        {
            return NotFound();
        }

        Context.Steps.Remove(step);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}