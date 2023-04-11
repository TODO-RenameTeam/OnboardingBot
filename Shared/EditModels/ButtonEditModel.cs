using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.Models;

namespace OnboardingBot.Shared.EditModels;

public class ButtonEditModel
{
    [Required] public string Name { get; set; }

    [Required] public string Key { get; set; }

    public ButtonType Type { get; set; } = ButtonType.Command;
}