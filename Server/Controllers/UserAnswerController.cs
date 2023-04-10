using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Shared.Entities;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserTestAnswerController : ControllerBase
{
    private DBContext Context;

    public UserTestAnswerController(DBContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserTestAnswerEntity>>> GetAll()
    {
        return Context.UserTestAnswers.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserTestAnswerEntity>> GetByID(Guid id)
    {
        var userTestAnswer = await Context.UserTestAnswers.FindAsync(id);
        if (userTestAnswer == null)
        {
            return NotFound();
        }

        return userTestAnswer;
    }

    [HttpPost("answer")]
    public async Task<IActionResult> AddAnswer(Guid testId, long telegramUserId, Guid questionId,
        Guid answerId)
    {
        var user = Context.Users.FirstOrDefault(x => x.TelegramID == telegramUserId);
        if (user == null)
        {
            return NotFound();
        }

        var entity = Context.UserTestAnswers.Include(x => x.Answers)
            .FirstOrDefault(x => x.TestID == testId && x.UserID == user.ID);
        if (entity == null)
        {
            entity = new()
            {
                UserID = user.ID,
                DateTimeStarting = default,
                TestID = testId
            };
            Context.Add(entity);
        }

        if (entity.Answers.FirstOrDefault(x => x.QuestionID == questionId) != null)
        {
            return BadRequest();
        }

        entity.Answers.Add(new()
        {
            UserID = user.ID,
            AnswerID = answerId,
            QuestionID = questionId
        });

        await Context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<UserTestAnswerEntity>> Update(Guid id, UserTestAnswerEntity userTestAnswer)
    {
        userTestAnswer.ID = id;

        Context.Attach(userTestAnswer);
        Context.Entry(userTestAnswer).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(userTestAnswer.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userTestAnswer = await Context.UserTestAnswers.FindAsync(id);
        if (userTestAnswer == null)
        {
            return NotFound();
        }

        Context.UserTestAnswers.Remove(userTestAnswer);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}