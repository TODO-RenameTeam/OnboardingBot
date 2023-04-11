using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserTestAnswerController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public UserTestAnswerController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserTestAnswerViewModel>>> GetAll()
    {
        var res = Context.UserTestAnswers.ToList();

        return res.Select(x => Mapper.Map<UserTestAnswerViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserTestAnswerViewModel>> GetByID(Guid id)
    {
        var userTestAnswer = await Context.UserTestAnswers.FindAsync(id);
        if (userTestAnswer == null)
        {
            return NotFound();
        }

        return Mapper.Map<UserTestAnswerViewModel>(userTestAnswer);
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
    public async Task<ActionResult<UserTestAnswerViewModel>> Update(Guid id, UserTestAnswerViewModel userTestAnswer)
    {
        var entity = Mapper.Map<UserTestAnswerEntity>(userTestAnswer);
        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
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