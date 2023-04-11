namespace OnboardingBot.Shared.ViewModels;

public class RoleOnboardingViewModel
{
    public Guid ID { get; set; }
    public Guid PositionID { get; set; }

    public int StepsCount { get; set; }
    public HashSet<UserOnboardingViewModel>? Steps { get; set; } = new();
}