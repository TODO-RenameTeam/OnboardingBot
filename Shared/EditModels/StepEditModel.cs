using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared.EditModels;

public class StepEditModel
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Text { get; set; } = String.Empty;
    
    public HashSet<string>? Images { get; set; } = new();
    public HashSet<string>? Urls { get; set; } = new();

    public int QuizesCount { get; set; } = 0;
    
    public Guid? PositionID { get; set; }
    
    public HashSet<QuizViewModel>? Quizes { get; set; } = new();
}