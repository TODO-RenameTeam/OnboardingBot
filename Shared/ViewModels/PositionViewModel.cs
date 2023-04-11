namespace OnboardingBot.Shared.ViewModels;

public class PositionViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? MainUserID { get; set; }
    public UserViewModel? MainUser { get; set; }
}