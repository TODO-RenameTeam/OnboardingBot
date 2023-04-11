using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public QuizController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuizViewModel>>> GetAll()
    {
        var res = Context.Quizes.ToList();

        return res.Select(x => Mapper.Map<QuizViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuizViewModel>> GetByID(Guid id)
    {
        var quiz = Context.Quizes
            .FirstOrDefault(x => x.ID == id);

        if (quiz == null)
        {
            return NotFound();
        }

        return Mapper.Map<QuizViewModel>(quiz);
    }

    [HttpPost]
    public async Task<ActionResult<QuizViewModel>> Create(QuizEditModel quiz)
    {
        var entity = Mapper.Map<QuizEntity>(quiz);

        Context.Quizes.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<QuizViewModel>> Update(Guid id, QuizEntity quiz)
    {
        var entity = Mapper.Map<QuizEntity>(quiz);

        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var quiz = await Context.Quizes.FindAsync(id);
        if (quiz == null)
        {
            return NotFound();
        }

        Context.Quizes.Remove(quiz);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}