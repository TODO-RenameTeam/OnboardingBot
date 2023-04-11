using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.EditModels;

public class UserOnboardingEditModel
{
    [Required]
    public Guid UserID { get; set; }
    [Required]
    public Guid RoleOnboardingID { get; set; }
    [Required]
    public Guid UserCurrentStepID { get; set; }
}