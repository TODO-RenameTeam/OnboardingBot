using Refit;

namespace OnboardingBot.Shared.APIs.Bot;

public interface ITelegramBotInterface
{
    [Post("")]
    Task SentMessage(SentMessageModel model);
}

public class SentMessageModel
{
    public long userId { get; set; }
    public string text { get; set; }
}