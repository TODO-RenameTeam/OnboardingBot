using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность ответов.
/// </summary>
public class AnswerEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// Ответ.
    /// </summary>
    [Required]
    public string Answer { get; set; }
    
    public bool? IsValid { get; set; } = null!;
    public int? Mark { get; set; } = null!;
}