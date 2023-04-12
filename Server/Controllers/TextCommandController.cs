using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TextCommandController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;

    public TextCommandController(DBContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<TextCommandViewModel>>> GetAll()
    {
        var res = Context.TextCommands.Include(x=>x.Buttons)
            .Include(x=>x.Position)
            .Include(x => x.Quizes)
            .ToList();

        return res.Select(x => Mapper.Map<TextCommandViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TextCommandViewModel>> GetByID(Guid id)
    {
        var textCommand = Context.TextCommands
            .Include(x => x.Buttons)
            .Include(x=>x.Position)
            .Include(x => x.Quizes)
            .FirstOrDefault(x => x.ID == id);

        if (textCommand == null)
        {
            return NotFound();
        }

        return Mapper.Map<TextCommandViewModel>(textCommand);
    }

    [HttpPost]
    public async Task<ActionResult<TextCommandViewModel>> Create(TextCommandEditModel textCommand)
    {
        var entity = Mapper.Map<TextCommandEntity>(textCommand);
        entity.Quizes.Clear();

        Context.TextCommands.Add(entity);
        await Context.SaveChangesAsync();
        
        foreach (var quizViewModel in textCommand.Quizes)
        {
            var quiz = await Context.Quizes.FindAsync(quizViewModel.ID);
            if (quiz != null)
            {
                entity.Quizes.Add(quiz);
            }
        }

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<TextCommandViewModel>> Update(Guid id, TextCommandEditModel textCommand)
    {
        var entity = Mapper.Map<TextCommandEntity>(textCommand);

        entity.ID = id;
        entity.Quizes.Clear();
        entity.Buttons.Clear();

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync();

        entity = Context.TextCommands
            .Include(x => x.Quizes)
            .Include(x=>x.Buttons)
            .FirstOrDefault(x => x.ID == id);

        entity.Quizes.Clear();
        entity.Buttons.Clear();
        
        await Context.SaveChangesAsync();

        foreach (var quizViewModel in textCommand.Quizes)
        {
            var quiz = await Context.Quizes.FindAsync(quizViewModel.ID);
            if (quiz != null)
            {
                entity.Quizes.Add(quiz);
            }
        }
        
        foreach (var button in textCommand.Buttons)
        {
            var buttonEnt = await Context.Buttons.FindAsync(button.ID);
            if (buttonEnt != null)
            {
                entity.Buttons.Add(buttonEnt);
            }
            else
            {
                entity.Buttons.Add(Mapper.Map<ButtonEntity>(button));
            }
        }

        await Context.SaveChangesAsync();
        
        return await GetByID(entity.ID);
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