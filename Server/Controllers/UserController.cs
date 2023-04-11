using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public UserController(DBContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserViewModel>>> GetAll()
    {
        var res = Context.Tests.ToList();

        return res.Select(x => Mapper.Map<UserViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserViewModel>> GetByID(Guid id)
    {
        var user = await Context.Users.FindAsync(id);
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

        entity.TelegramID = null;
        Context.Users.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<UserViewModel>> Update(Guid id, UserEntity user)
    {
        var entity = Mapper.Map<UserEntity>(user);
        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        Context.Entry(entity).Property(x => x.TelegramID).IsModified = false;

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