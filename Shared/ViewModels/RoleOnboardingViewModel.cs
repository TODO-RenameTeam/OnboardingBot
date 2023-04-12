namespace OnboardingBot.Shared.ViewModels;

public class RoleOnboardingViewModel
{
    public Guid ID { get; set; }
    public Guid PositionID { get; set; }
    public PositionViewModel? Position { get; set; } = new();

    public int StepsCount { get; set; }
    public HashSet<UserOnboardingViewModel>? UserSteps { get; set; } = new();

    public HashSet<StepViewModel>? Steps { get; set; } = new();
    public HashSet<RoleOnboardingStepViewModel>? StepPositions { get; set; } = new();
}

public class RoleOnboardingStepViewModel
{
    public Guid RoleOnboardingID { get; set; }

    public RoleOnboardingViewModel? RoleOnboarding { get; set; }
    public Guid StepID { get; set; }
    public StepViewModel? Step { get; set; }
    public int Position { get; set; }
}