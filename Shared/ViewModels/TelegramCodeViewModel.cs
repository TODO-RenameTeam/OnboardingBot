namespace OnboardingBot.Shared.ViewModels;

public class TelegramCodeViewModel
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public DateTime DateTimeCreate { get; set; } = DateTime.Now;
    public DateTime DateTimeExist { get; set; } = DateTime.Now.AddMinutes(360);
    public string Code { get; set; }
}