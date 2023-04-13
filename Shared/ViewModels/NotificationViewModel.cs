namespace OnboardingBot.Shared.ViewModels;

public class NotificationViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public int Minutes { get; set; }
    public int? Count { get; set; }
    public int? Sending { get; set; }
    public DateTime? DateTimeStart { get; set; }
    public Guid? PositionID { get; set; }
    public PositionViewModel? Position { get; set; }

}