using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.Models;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность кнопки.
/// </summary>
public class ButtonEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// Название кнопки.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Значение кнопки.
    /// </summary>
    [Required]
    public string Key { get; set; }

    /// <summary>
    /// Тип кнопки.
    /// Связано с параметром Key.
    /// </summary>
    public ButtonType Type { get; set; } = ButtonType.Command;

    public HashSet<TextCommandEntity>? TextCommands { get; set; } = new();
}