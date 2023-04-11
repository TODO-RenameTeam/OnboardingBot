using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public QuestionController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuestionViewModel>>> GetAll()
    {
        var res = Context.Questions.ToList();

        return res.Select(x => Mapper.Map<QuestionViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionViewModel>> GetByID(Guid id)
    {
        var question = Context.Questions.Include(x => x.Answers)
            .FirstOrDefault(x => x.ID == id);

        if (question == null)
        {
            return NotFound();
        }

        return Mapper.Map<QuestionViewModel>(question);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionViewModel>> Create(QuestionEditModel question)
    {
        var entity = Mapper.Map<QuestionEntity>(question);

        Context.Questions.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<QuestionViewModel>> Update(Guid id, QuestionEntity question)
    {
        var entity = Mapper.Map<QuestionEntity>(question);

        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var question = await Context.Questions.FindAsync(id);
        if (question == null)
        {
            return NotFound();
        }

        Context.Questions.Remove(question);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}