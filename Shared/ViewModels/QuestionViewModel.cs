using OnboardingBot.Shared.Models;

namespace OnboardingBot.Shared.ViewModels;

public class QuestionViewModel
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AnswerDisplayingType AnswerDisplayingType { get; set; } = AnswerDisplayingType.TextInButton;

    public HashSet<AnswerViewModel>? Answers { get; set; } = new();
}