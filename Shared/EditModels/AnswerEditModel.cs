using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.EditModels;

public class AnswerEditModel
{
    [Required]
    public string Answer { get; set; }

    public bool? IsValid { get; set; } = null!;
    public int? Mark { get; set; } = null!;
}