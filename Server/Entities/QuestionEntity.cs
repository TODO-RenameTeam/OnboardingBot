using System.ComponentModel.DataAnnotations;
using OnboardingBot.Shared.Models;

namespace OnboardingBot.Server.Entities;

/// <summary>
/// Сущность вопросов.
/// </summary>
public class QuestionEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    [Required]
    public string Description { get; set; }

    /// <summary>
    /// Вариант отображения ответов на вопрос.
    /// </summary>
    public AnswerDisplayingType AnswerDisplayingType { get; set; } = AnswerDisplayingType.TextInButton;

    /// <summary>
    /// Сущности вариантов ответов.
    /// </summary>
    public HashSet<AnswerEntity>? Answers { get; set; } = new();
}