using Microsoft.EntityFrameworkCore;
using OnboardingBot.Shared.APIs.Bot;
using Quartz;

namespace OnboardingBot.Server.Jobs;

public class NotificationSender : IJob
{
    private DBContext Context;
    private ITelegramBotInterface TelegramBotInterface;

    public NotificationSender(DBContext context, ITelegramBotInterface telegramBotInterface)
    {
        Context = context;
        TelegramBotInterface = telegramBotInterface;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("[{0}] Start sending notification...", DateTime.Now);
        int count = 0;
        var entities = Context.Notifications
            .Include(x => x.Position).ToList();

        var users = Context.Users.ToList();

        foreach (var entity in entities.Where(x => x.DateTimeStart != null))
        {
            if (entity.DateTimeStart != null && entity.Count > entity.Sending)
            {
                var minutes = entity.Minutes *
                               entity.Sending.GetValueOrDefault(0);

                var res = entity.DateTimeStart.Value.AddMinutes(minutes)
                    .TimeOfDay;
                var time = DateTime.Now.TimeOfDay;
                if (res.Hours <= time.Hours && res.Minutes <= time.Minutes)
                {
                    foreach (var user in users)
                    {
                        if (entity.PositionID != null)
                        {
                            if (user.PositionID != entity.PositionID)
                            {
                                continue;
                            }
                        }

                        if (user.TelegramID.GetValueOrDefault(0) != 0)
                        {
                            await TelegramBotInterface.SentMessage(new()
                            {
                                text = entity.Text,
                                userId = user.TelegramID.GetValueOrDefault()
                            });
                            count++;
                        }
                    }

                    entity.Sending++;
                    await Context.SaveChangesAsync();
                }
            }
        }

        Console.WriteLine("Sended notification: {0}", count);
    }
}