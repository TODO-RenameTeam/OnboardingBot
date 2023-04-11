using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.Models;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class QuestionEditModel
{
    [Required] public string Title { get; set; }

    [Required] public string Description { get; set; }

    public AnswerDisplayingType AnswerDisplayingType { get; set; } = AnswerDisplayingType.TextInButton;
    public HashSet<AnswerViewModel>? Answers { get; set; } = new();
}