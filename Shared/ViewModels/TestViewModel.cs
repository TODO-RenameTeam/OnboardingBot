namespace OnboardingBot.Shared.ViewModels;

public class TestViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? PositionID { get; set; }
    public HashSet<QuestionViewModel> Questions { get; set; } = new();
    public HashSet<ButtonViewModel>? Buttons { get; set; } = new();
}