using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Server.Entities;

public class QuizEntity
{
    [Key]
    public Guid ID { get; set; }
    
    [Required]
    public string Text { get; set; }
    public List<string> Options { get; set; } = new();
    public int RightOptionID { get; set; }
}