using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Shared.Entities;

/// <summary>
/// Сущность текстовых комманд.
/// Могут содержать видео и картинки.
/// </summary>
public class TextCommandEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Слово, на которое будет вызываться команда.
    /// </summary>
    public string ExecutingCommand { get; set; }

    /// <summary>
    /// Текст, отправляемый пользователю.
    /// </summary>
    public string Text { get; set; } = String.Empty;

    /// <summary>
    /// ID должности, для которой будет видна эта команда.
    /// Если не указана - видна для всех.
    /// </summary>
    public Guid? PositionID { get; set; }

    /// <summary>
    /// Сущность должности.
    /// </summary>
    [ForeignKey(nameof(PositionID))] public PositionEntity? Position { get; set; }

    /// <summary>
    /// Сущность кнопок.
    /// </summary>
    public HashSet<ButtonEntity>? Buttons { get; set; } = new();
}