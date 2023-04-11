namespace OnboardingBot.Shared.ViewModels;

public class UserOnboardingViewModel
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid RoleOnboardingID { get; set; }
    public Guid UserCurrentStepID { get; set; }
}