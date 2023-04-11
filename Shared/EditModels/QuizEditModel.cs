using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.EditModels;

public class QuizEditModel
{
    [Required]
    public string Text { get; set; }
    public List<string> Options { get; set; } = new();
    public int RightOptionID { get; set; }
}