namespace OnboardingBot.Shared.ViewModels;

public class UserOnboardingViewModel
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    
    public UserViewModel? User { get; set; }
    public Guid RoleOnboardingID { get; set; }
    public RoleOnboardingViewModel? RoleOnboarding { get; set; }
    public Guid UserCurrentStepID { get; set; }
    public StepViewModel? UserCurrentStep { get; set; }

    public DateTime DateTimeStart { get; set; } = DateTime.Now;
    public DateTime? DateTimeEnd { get; set; }
}