using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Server.Services;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelegramCodeController : ControllerBase
{
    private DBContext Context;
    private CodeService CodeService;
    private IMapper Mapper;

    public TelegramCodeController(DBContext context, CodeService codeService, IMapper mapper)
    {
        Context = context;
        CodeService = codeService;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<TelegramCodeViewModel>>> GetAll()
    {
        var res = Context.TelegramCodes.ToList();

        return res.Select(x => Mapper.Map<TelegramCodeViewModel>(x)).ToList();
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<TelegramCodeViewModel>> GetByID(Guid id)
    {
        var code = await Context.TelegramCodes.FindAsync(id);
        if (code == null)
        {
            return NotFound();
        }

        return Mapper.Map<TelegramCodeViewModel>(code);
    }


    [HttpGet("code/{code}")]
    public async Task<ActionResult<TelegramCodeViewModel>> GetByCode(string code)
    {
        var entity = Context.TelegramCodes.AsNoTracking().AsEnumerable()
            .FirstOrDefault(x => x.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        if (entity == null)
        {
            return NotFound();
        }

        return Mapper.Map<TelegramCodeViewModel>(entity);
    }

    [HttpPost("generate")]
    public async Task<ActionResult<TelegramCodeViewModel>> Generate(Guid userId)
    {
        var res = Context.TelegramCodes.FirstOrDefault(x => x.UserID == userId);
        if (res == null)
        {
            res = await CodeService.GenerateCode(userId);
        }

        return Mapper.Map<TelegramCodeViewModel>(res);
    }

    [HttpPost("connect")]
    public async Task<IActionResult> Connect(string code, long telegramUserId)
    {
        var entityId = (await GetByCode(code)).Value?.ID;
        if (entityId == null)
        {
            return NotFound();
        }

        var entity = await Context.TelegramCodes.FindAsync(entityId);
        if (entity == null)
        {
            return NotFound();
        }

        // if (entity.DateTimeExist <= DateTime.Now)
        // {
        //     return BadRequest("Код привязки более недействителен.");
        // }

        var user = await Context.Users.FindAsync(entity.UserID);
        if (user == null)
        {
            return NotFound();
        }

        user.TelegramID = telegramUserId;
        Context.TelegramCodes.Remove(entity);
        await Context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var code = await Context.TelegramCodes.FindAsync(id);
        if (code == null)
        {
            return NotFound();
        }

        Context.TelegramCodes.Remove(code);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}