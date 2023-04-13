using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class PositionEditModel
{
    [Required] public string Name { get; set; }

    public string? Description { get; set; }
}