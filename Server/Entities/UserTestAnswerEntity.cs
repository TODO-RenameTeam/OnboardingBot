using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность сбора ответов с теста.
/// </summary>
public class UserTestAnswerEntity
{
    public Guid ID { get; set; }

    public Guid UserID { get; set; }

    [ForeignKey(nameof(UserID))] public UserEntity? User { get; set; }

    public Guid TestID { get; set; }
    [ForeignKey(nameof(TestID))] public TestEntity Test { get; set; }

    /// <summary>
    /// Сущности ответов.
    /// </summary>
    public HashSet<UserAnswerEntity>? Answers { get; set; } = new();

    /// <summary>
    /// Дата и время начала тестирования.
    /// </summary>
    public DateTime DateTimeStarting { get; set; } = DateTime.Now;

    /// <summary>
    /// Дата и время окончания тестирования.
    /// </summary>
    public DateTime? DateTimeEnding { get; set; }
}