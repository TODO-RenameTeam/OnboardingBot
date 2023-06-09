namespace OnboardingBot.Shared.ViewModels;

public class QuizViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public List<string> Options { get; set; } = new();
    public int RightOptionID { get; set; }
    
    public HashSet<TextCommandViewModel>? TextCommands { get; set; } = new();
    public HashSet<StepViewModel>? Steps { get; set; } = new();
}