using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

public class StepEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Текст, отправляемый пользователю.
    /// </summary>
    [Required]
    public string Text { get; set; } = String.Empty;

    public HashSet<string>? Images { get; set; } = new();
    public HashSet<string>? Urls { get; set; } = new();

    public int QuizesCount { get; set; } = 0;

    /// <summary>
    /// ID должности, для которой будет видна эта команда.
    /// Если не указана - видна для всех.
    /// </summary>
    public Guid? PositionID { get; set; }

    /// <summary>
    /// Сущность должности.
    /// </summary>
    [ForeignKey(nameof(PositionID))]
    public PositionEntity? Position { get; set; }
}