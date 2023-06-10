using OnboardingBot.Server.Jobs;
using OnboardingBot.Shared.APIs.Bot;
using Quartz;
using Quartz.Impl;

namespace OnboardingBot.Server.Services;

public class NotificationService
{
    private DBContext Context;
    private ITelegramBotInterface TelegramBotInterface;
    private JobFactory JobFactory;
    private NotificationSender sender;

    public NotificationService(DBContext context, ITelegramBotInterface telegramBotInterface, JobFactory jobFactory)
    {
        Context = context;
        TelegramBotInterface = telegramBotInterface;
        JobFactory = jobFactory;
    }

    public async Task Start()
    {
        IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
        await scheduler.Start();
        scheduler.JobFactory = JobFactory;

        IJobDetail job = JobBuilder.Create<NotificationSender>().Build();
 
        ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
            .WithIdentity("trigger1", "group1")     // идентифицируем триггер с именем и группой
            .StartNow()                            // запуск сразу после начала выполнения
            .WithSimpleSchedule(x => x            // настраиваем выполнение действия
                .WithIntervalInMinutes(1)          // через 1 минуту
                .RepeatForever())                   // бесконечное повторение
            .Build();                               // создаем триггер
 
        await scheduler.ScheduleJob(job, trigger);        // начинаем выполнение работы
    }
}