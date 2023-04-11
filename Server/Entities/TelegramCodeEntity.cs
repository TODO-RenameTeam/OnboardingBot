using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность привязки Telegram к аккаунту.
/// </summary>
public class TelegramCodeEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// ID пользователя в системе.
    /// </summary>
    [Required]
    public Guid UserID { get; set; }

    /// <summary>
    /// Сущность пользователя в системе.
    /// </summary>
    [ForeignKey(nameof(UserID))]
    public UserEntity User { get; set; }

    /// <summary>
    /// Дата и время создания сущности.
    /// </summary>
    public DateTime DateTimeCreate { get; set; } = DateTime.Now;

    /// <summary>
    /// Дата и время действия сущности.
    /// </summary>
    public DateTime DateTimeExist { get; set; } = DateTime.Now.AddMinutes(360);

    /// <summary>
    /// Код привязки.
    /// </summary>
    public string Code { get; set; }
}