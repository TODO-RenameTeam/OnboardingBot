using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class RoleOnboardingEditModel
{
    [Required] public Guid PositionID { get; set; }

    public int StepsCount { get; set; }
    public HashSet<UserOnboardingViewModel>? Steps { get; set; } = new();
}