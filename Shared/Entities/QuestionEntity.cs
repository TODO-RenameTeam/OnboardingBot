using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.Entities;

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
    public string Title { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
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
    public string Answer { get; set; }

    public bool? IsValid { get; set; } = null!;
    public int? Mark { get; set; } = null!;
}

/// <summary>
/// Перечисление вариантов отображение ответов на вопрос.
/// </summary>
public enum AnswerDisplayingType
{
    [Display(Name = "Текст в кнопке", Description = "Ответы будут отображаться в кнопке.")]
    TextInButton,

    [Display(Name = "Цифры в кнопке",
        Description = "Ответы будут перечислены в тексте и пронумерованы, и кнопки будут помечены цифрами.")]
    NumbersInButton,
}