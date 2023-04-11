using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class TestEditModel
{
    [Required] public string Name { get; set; }
    public string? Description { get; set; }

    public Guid? PositionID { get; set; }

    public HashSet<QuestionViewModel> Questions { get; set; } = new();
    public HashSet<ButtonViewModel>? Buttons { get; set; } = new();
}