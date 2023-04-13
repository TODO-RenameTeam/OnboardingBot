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
public class NotificationController : ControllerBase
{
    private DBContext Context;
    private IMapper Mapper;
    private ITelegramBotInterface TelegramBotInterface;

    public NotificationController(DBContext context, IMapper mapper, ITelegramBotInterface telegramBotInterface)
    {
        Context = context;
        Mapper = mapper;
        TelegramBotInterface = telegramBotInterface;
    }

    [HttpGet]
    public async Task<ActionResult<List<NotificationViewModel>>> GetAll()
    {
        var res = Context.Notifications
            .Include(x => x.Position)
            .ToList();

        return res.Select(x => Mapper.Map<NotificationViewModel>(x)).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NotificationViewModel>> GetByID(Guid id)
    {
        var notification = Context.Notifications
            .Include(x => x.Position)
            .FirstOrDefault(x => x.ID == id);
        if (notification == null)
        {
            return NotFound();
        }

        return Mapper.Map<NotificationViewModel>(notification);
    }

    [HttpPost]
    public async Task<ActionResult<NotificationViewModel>> Create(NotificationEditModel notification)
    {
        var entity = Mapper.Map<NotificationEntity>(notification);
        entity.Position = null;

        var position = await Context.Positions.FindAsync(notification);
        if (position != null)
        {
            entity.PositionID = position.ID;
            entity.Position = position;
        }

        Context.Notifications.Add(entity);
        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPut]
    public async Task<ActionResult<NotificationViewModel>> Update(Guid id, NotificationEntity notification)
    {
        var entity = Mapper.Map<NotificationEntity>(notification);
        entity.Position = null;
        entity.ID = id;

        Context.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        var position = await Context.Positions.FindAsync(notification.PositionID);
        if (position != null)
        {
            entity.PositionID = position.ID;
            entity.Position = position;
        }

        await Context.SaveChangesAsync();

        return await GetByID(entity.ID);
    }

    [HttpPost("start")]
    public async Task<ActionResult> StartSending(Guid id)
    {
        var entity = Context.Notifications.Include(x => x.Position)
            .ThenInclude(x => x.Users).FirstOrDefault(x => x.ID == id);
        entity.DateTimeStart = DateTime.Now;
        entity.Sending = 0;
        await Context.SaveChangesAsync();

        await Start(entity);

        if (entity == null)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var notification = await Context.Notifications.FindAsync(id);
        if (notification == null)
        {
            return NotFound();
        }

        Context.Notifications.Remove(notification);
        await Context.SaveChangesAsync();

        return NoContent();
    }

    private async Task Start(NotificationEntity entity)
    {
        if (entity.DateTimeStart != null && entity.Count != entity.Sending)
        {
            var res = entity.DateTimeStart.Value.AddMinutes(entity.Minutes).TimeOfDay;
            var time = DateTime.Now.TimeOfDay;
            if (res.Hours == time.Hours && res.Minutes == time.Minutes)
            {
                foreach (var user in entity.Position.Users)
                {
                    if (user.TelegramID != null)
                    {
                        await TelegramBotInterface.SentMessage(new()
                        {
                            text = entity.Text,
                            userId = (long)user.TelegramID
                        });
                    }
                }

                entity.Sending++;
                await Context.SaveChangesAsync();
            }

            if (entity.Count != entity.Sending)
            {
                await Start(entity);
            }
        }
    }
}