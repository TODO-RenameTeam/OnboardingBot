using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserQuestionController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public UserQuestionController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserQuestionViewModel>>> GetAll()
    {
        var res = Context.UserQuestions
            .Include(x => x.UserQuestion)
            .ToList();

        return res.Select(x => Mapper.Map<UserQuestionViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserQuestionViewModel>> GetByID(Guid id)
    {
        var userQuestion = Context.UserQuestions
            .Include(x => x.UserQuestion)
            .FirstOrDefault(x => x.ID == id);
        if (userQuestion == null)
        {
            return NotFound();
        }

        return Mapper.Map<UserQuestionViewModel>(userQuestion);
    }

    [HttpGet("user/id/{userId}")]
    public async Task<ActionResult<List<UserQuestionViewModel>>> GetByUserID(Guid userId)
    {
        var userQuestion = Context.UserQuestions
            .Include(x => x.UserQuestion)
            .Where(x => x.UserQuestionID == userId);
        if (userQuestion == null)
        {
            return NotFound();
        }

        return userQuestion.Select(x => Mapper.Map<UserQuestionViewModel>(x)).ToList();
    }


    [HttpPost]
    public async Task<ActionResult<UserQuestionViewModel>> Create(UserQuestionEditModel userQuestion)
    {
        var entity = Mapper.Map<UserQuestionEntity>(userQuestion);

        entity.Answer = null;
        entity.DateTimeAnswering = null;

        Context.UserQuestions.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<UserQuestionViewModel>> Update(Guid id, UserQuestionEntity userQuestion)
    {
        var entity = Mapper.Map<UserQuestionEntity>(userQuestion);
        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        Context.Entry(entity).Property(x => x.DateTimeAnswering).IsModified = false;

        if (entity.Answer != null)
        {
            entity.DateTimeAnswering = DateTime.Now;
        }
        else
        {
            Context.Entry(entity).Property(x => x.DateTimeQuestion).IsModified = false;
        }

        // todo SEND MESSAGE TO TG BOT
        
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userQuestion = await Context.UserQuestions.FindAsync(id);
        if (userQuestion == null)
        {
            return NotFound();
        }

        Context.UserQuestions.Remove(userQuestion);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}