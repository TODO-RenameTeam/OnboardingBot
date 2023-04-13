using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.EditModels;

public class UserQuestionEditModel
{
    [Required] public string Question { get; set; }

    public string? Answer { get; set; }
    [Required] public Guid UserQuestionID { get; set; }
}