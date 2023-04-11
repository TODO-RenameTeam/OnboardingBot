namespace OnboardingBot.Shared.ViewModels;

public class AnswerViewModel
{
    public Guid ID { get; set; }
    public string Answer { get; set; }
    public bool? IsValid { get; set; } = null!;
    public int? Mark { get; set; } = null!;
}