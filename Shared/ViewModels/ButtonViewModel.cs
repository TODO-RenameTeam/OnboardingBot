using OnboardingBot.Shared.Models;

namespace OnboardingBot.Shared.ViewModels;

public class ButtonViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public ButtonType Type { get; set; } = ButtonType.Command;
}