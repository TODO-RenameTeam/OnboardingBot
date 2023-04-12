using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserOnboardingController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public UserOnboardingController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserOnboardingViewModel>>> GetAll()
    {
        var res = Context.UserOnboardings.ToList();

        return res.Select(x => Mapper.Map<UserOnboardingViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserOnboardingViewModel>> GetByID(Guid id)
    {
        var userOnboarding = Context.UserOnboardings.Include(x => x.User)
            .Include(x => x.RoleOnboarding)
            .Include(x => x.UserCurrentStep)
            .FirstOrDefault(x => x.ID == id);

        if (userOnboarding == null)
        {
            return NotFound();
        }

        return Mapper.Map<UserOnboardingViewModel>(userOnboarding);
    }
    
    [HttpGet("user/id/{userId}")]
    public async Task<ActionResult<List<UserOnboardingViewModel>>> GetByUserID(Guid userId)
    {
        var userOnboarding = Context.UserOnboardings.Include(x => x.User)
            .Include(x => x.RoleOnboarding)
            .Include(x => x.UserCurrentStep)
            .Where(x => x.UserID == userId);

        if (userOnboarding == null)
        {
            return NotFound();
        }

        return userOnboarding.Select(x=> Mapper.Map<UserOnboardingViewModel>(x)).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<UserOnboardingViewModel>> Create(UserOnboardingEditModel userOnboarding)
    {
        var entity = Mapper.Map<UserOnboardingEntity>(userOnboarding);

        Context.UserOnboardings.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<UserOnboardingViewModel>> Update(Guid id, UserOnboardingEntity userOnboarding)
    {
        var entity = Mapper.Map<UserOnboardingEntity>(userOnboarding);

        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userOnboarding = await Context.UserOnboardings.FindAsync(id);
        if (userOnboarding == null)
        {
            return NotFound();
        }

        Context.UserOnboardings.Remove(userOnboarding);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}