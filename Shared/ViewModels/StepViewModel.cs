namespace OnboardingBot.Shared.ViewModels;

public class StepViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Text { get; set; } = String.Empty;
    public HashSet<string>? Images { get; set; } = new();
    public HashSet<string>? Urls { get; set; } = new();
    public int QuizesCount { get; set; } = 0;
    public Guid? PositionID { get; set; }
    
    
    public HashSet<QuizViewModel>? Quizes { get; set; } = new();
}