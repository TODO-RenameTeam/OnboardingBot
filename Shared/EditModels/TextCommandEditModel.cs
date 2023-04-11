using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class TextCommandEditModel
{
    public string Name { get; set; }

    public string Template { get; set; }

    public string Text { get; set; } = String.Empty;

    public HashSet<string>? Images { get; set; } = new();
    public HashSet<string>? Urls { get; set; } = new();

    public int QuizesCount { get; set; } = 0;

    public Guid? PositionID { get; set; }

    public HashSet<ButtonViewModel>? Buttons { get; set; } = new();
}