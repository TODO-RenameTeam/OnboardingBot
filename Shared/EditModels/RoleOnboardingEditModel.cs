using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class RoleOnboardingEditModel
{
    [Required] public Guid PositionID { get; set; }
    public PositionViewModel? Position { get; set; }

    public int StepsCount { get; set; }
    public HashSet<UserOnboardingViewModel>? UserSteps { get; set; } = new();
    
    public HashSet<StepViewModel>? Steps { get; set; } = new();
    public HashSet<RoleOnboardingViewModel>? StepPositions { get; set; } = new();
}