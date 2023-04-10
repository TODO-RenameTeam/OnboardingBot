using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Shared.Entities;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TextCommandController : ControllerBase
{
    private DBContext Context;

    public TextCommandController(DBContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<TextCommandEntity>>> GetAll()
    {
        return Context.TextCommands.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TextCommandEntity>> GetByID(Guid id)
    {
        var textCommand = Context.TextCommands
            .Include(x => x.Buttons)
            .FirstOrDefault(x => x.ID == id);

        if (textCommand == null)
        {
            return NotFound();
        }

        return textCommand;
    }

    [HttpPost]
    public async Task<ActionResult<TextCommandEntity>> Create(TextCommandEntity textCommand)
    {
        Context.TextCommands.Add(textCommand);
        await Context.SaveChangesAsync();

        return await GetByID(textCommand.ID);
    }

    [HttpPut]
    public async Task<ActionResult<TextCommandEntity>> Update(Guid id, TextCommandEntity textCommand)
    {
        textCommand.ID = id;

        Context.Attach(textCommand);
        Context.Entry(textCommand).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        return await GetByID(textCommand.ID);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var textCommand = await Context.TextCommands.FindAsync(id);
        if (textCommand == null)
        {
            return NotFound();
        }

        Context.TextCommands.Remove(textCommand);
        await Context.SaveChangesAsync();

        return NoContent();
    }
}