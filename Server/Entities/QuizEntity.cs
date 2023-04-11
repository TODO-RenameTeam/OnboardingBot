using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность опроса.
/// </summary>
public class QuizEntity
{
    [Key] public Guid ID { get; set; }
    
    /// <summary>
    /// Название в системе.
    /// </summary>
    [Required]
    public string Name { get; set; }

    [Required] public string Text { get; set; }
    public List<string> Options { get; set; } = new();
    public int RightOptionID { get; set; }

    public HashSet<TextCommandEntity>? TextCommands { get; set; } = new();
    public HashSet<StepEntity>? Steps { get; set; } = new();
}