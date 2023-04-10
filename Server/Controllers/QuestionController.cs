using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Shared.Entities;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private DBContext Context;

    public QuestionController(DBContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuestionEntity>>> GetAll()
    {
        return Context.Questions.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionEntity>> GetByID(Guid id)
    {
        var question = Context.Questions.Include(x=>x.Answers)
            .FirstOrDefault(x => x.ID == id);

        if (question == null)
        {
            return NotFound();
        }

        return question;
    }

    [HttpPost]
    public async Task<ActionResult<QuestionEntity>> Create(QuestionEntity question)
    {
        Context.Questions.Add(question);
        await Context.SaveChangesAsync();

        return await GetByID(question.ID);
    }

    [HttpPut]
    public async Task<ActionResult<QuestionEntity>> Update(Guid id, QuestionEntity question)
    {
        question.ID = id;

        Context.Attach(question);
        Context.Entry(question).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(question.ID);
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