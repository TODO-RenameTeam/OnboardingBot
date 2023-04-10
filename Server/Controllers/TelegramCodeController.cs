using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Services;
using OnboardingBot.Shared.Entities;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelegramCodeController : ControllerBase
{
    private DBContext Context;
    private CodeService CodeService;

    public TelegramCodeController(DBContext context, CodeService codeService)
    {
        Context = context;
        CodeService = codeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TelegramCodeEntity>>> GetAll()
    {
        return Context.TelegramCodes.ToList();
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<TelegramCodeEntity>> GetByID(Guid id)
    {
        var code = await Context.TelegramCodes.FindAsync(id);
        if (code == null)
        {
            return NotFound();
        }

        return code;
    }


    [HttpGet("code/{code}")]
    public async Task<ActionResult<TelegramCodeEntity>> GetByCode(string code)
    {
        var entity = Context.TelegramCodes.AsNoTracking().AsEnumerable()
            .FirstOrDefault(x => x.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }

    [HttpPost("generate")]
    public async Task<ActionResult<TelegramCodeEntity>> Generate(Guid userId)
    {
        var res = await CodeService.GenerateCode(userId);
        return res;
    }

    [HttpPost("connect")]
    public async Task<IActionResult> Connect(string code, long telegramUserId)
    {
        var entity = (await GetByCode(code)).Value;
        if (entity == null)
        {
            return NotFound();
        }

        if (entity.DateTimeExist <= DateTime.Now)
        {
            return BadRequest("Код привязки более недействителен.");
        }

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