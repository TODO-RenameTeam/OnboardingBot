using System.ComponentModel.DataAnnotations;

namespace OnboardingBot.Shared.Models;

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