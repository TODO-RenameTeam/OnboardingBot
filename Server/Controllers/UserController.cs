using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.APIs.Bot;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;
    private ITelegramBotInterface TelegramBotInterface;

    public UserController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserViewModel>>> GetAll()
    {
        var res = Context.Users
            .Include(x => x.Position)
            .ToList();

        return res.Select(x => Mapper.Map<UserViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserViewModel>> GetByID(Guid id)
    {
        var user = Context.Users
            .Include(x => x.Position)
            .FirstOrDefault(x => x.ID == id);
        if (user == null)
        {
            return NotFound();
        }

        return Mapper.Map<UserViewModel>(user);
    }


    [HttpGet("tg")]
    public async Task<ActionResult<UserViewModel>> GetByTelegramID(long id)
    {
        var user = Context.Users
            .Include(x => x.Position)
            .FirstOrDefault(x => x.TelegramID == id);
        if (user == null)
        {
            return NotFound();
        }

        return Mapper.Map<UserViewModel>(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserViewModel>> Create(UserEditModel user)
    {
        var entity = Mapper.Map<UserEntity>(user);
        entity.Position = null;

        var position = await Context.Positions.FindAsync(user.PositionID);
        if (position != null)
        {
            entity.PositionID = position.ID;
            entity.Position = position;
        }

        entity.TelegramID = null;
        Context.Users.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPost("message")]
    public async Task<ActionResult> SentMessage(Guid id, string text)
    {
        var entity = await Context.Users.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        if (entity.TelegramID == null)
        {
            return NotFound();
        }

        await TelegramBotInterface.SentMessage(new()
        {
            userId = (long)entity.TelegramID,
            text = text
        });

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<UserViewModel>> Update(Guid id, UserEntity user)
    {
        var entity = Mapper.Map<UserEntity>(user);
        entity.Position = null;
        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        Context.Entry(entity).Property(x => x.TelegramID).IsModified = false;

        var position = await Context.Positions.FindAsync(user.PositionID);
        if (position != null)
        {
            entity.PositionID = position.ID;
            entity.Position = position;
        }

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await Context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        Context.Users.Remove(user);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}