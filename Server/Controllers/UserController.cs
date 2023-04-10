using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Services;
using OnboardingBot.Shared.Entities;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private DBContext Context;

    public UserController(DBContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserEntity>>> GetAll()
    {
        return Context.Users.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserEntity>> GetByID(Guid id)
    {
        var user = await Context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<UserEntity>> Create(UserEntity user)
    {
        user.TelegramID = null;
        Context.Users.Add(user);
        await Context.SaveChangesAsync();

        return await GetByID(user.ID);
    }

    [HttpPut]
    public async Task<ActionResult<UserEntity>> Update(Guid id, UserEntity user)
    {
        user.ID = id;

        Context.Attach(user);
        Context.Entry(user).State = EntityState.Modified;
        Context.Entry(user).Property(x => x.TelegramID).IsModified = false;

        await Context.SaveChangesAsync();

        return await GetByID(user.ID);
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