using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

public class TestEntity
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
    /// Описание теста.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// ID должности.
    /// Если не указано то действует для всех сотрудников.
    /// </summary>
    public Guid? PositionID { get; set; }
    
    /// <summary>
    /// Сущность должности.
    /// </summary>
    [ForeignKey(nameof(PositionID))]
    public PositionEntity? Position { get; set; }

    /// <summary>
    /// Сущности вопросов.
    /// </summary>
    public HashSet<QuestionEntity> Questions { get; set; } = new();
    
    /// <summary>
    /// Сущность кнопок, отображаемые перед и после тестом.
    /// </summary>
    public HashSet<ButtonEntity>? Buttons { get; set; } = new();
}