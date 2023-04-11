using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность должностей.
/// </summary>
public class PositionEntity
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
    /// Описание.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// ID ответственного сотрудника.
    /// </summary>
    public Guid? MainUserID { get; set; }

    [ForeignKey(nameof(MainUserID))] public UserEntity MainUser { get; set; }
}