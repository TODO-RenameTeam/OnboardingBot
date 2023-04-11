using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

public class UserQuestionEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key] public Guid ID { get; set; }

    /// <summary>
    /// Вопрос от сотрудника.
    /// </summary>
    [Required] public string Question { get; set; }
    
    /// <summary>
    /// Ответ от администрации.
    /// </summary>
    public string? Answer { get; set; }

    /// <summary>
    /// Дата и время когда задали вопрос.
    /// </summary>
    public DateTime DateTimeQuestion { get; set; } = DateTime.Now;

    /// <summary>
    /// Дата и время когда дали ответ.
    /// </summary>
    public DateTime? DateTimeAnswering { get; set; }
    
    /// <summary>
    /// ID сотрудника, задавшего вопрос.
    /// </summary>
    [Required] public Guid UserQuestionID { get; set; }
    [ForeignKey(nameof(UserQuestionID))] public UserEntity? UserQuestion { get; set; }
}