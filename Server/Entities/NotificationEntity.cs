using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingBot.Server.Entities;

public class NotificationEntity
{
    [Key]
    public Guid ID { get; set; }
    /// <summary>
    /// Название рассылки
    /// </summary>
    [Required]
    public string Name { get; set; }
    
    /// <summary>
    /// Текст рассылки
    /// </summary>
    [Required]
    public string Text { get; set; }
    
    /// <summary>
    /// Через какое кол-во минут отправлять
    /// </summary>
    [DefaultValue(0)]
    public int Minutes { get; set; }
    
    /// <summary>
    /// Кол-во отправлений
    /// </summary>
    [DefaultValue(0)]
    public int? Count { get; set; }
    
    /// <summary>
    /// Сколько отправлено
    /// </summary>
    [DefaultValue(0)]
    public int? Sending { get; set; }
    
    public DateTime? DateTimeStart { get; set; }
    
    public Guid? PositionID { get; set; }
    [ForeignKey(nameof(PositionID))]
    public PositionEntity? Position { get; set; }
}