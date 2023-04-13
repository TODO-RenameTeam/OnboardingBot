using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface INotificationController
{
    [Get("/api/notification")]
    Task<List<NotificationViewModel>> GetAll();
    
    [Get("/api/notification/{id}")]
    Task<NotificationViewModel> GetByID(Guid id);
    
    [Post("/api/notification")]
    Task<NotificationViewModel> Create(NotificationEditModel notification);
   
    [Post("/api/notification/start")]
    Task Start(Guid id);
    
    [Put("/api/notification")]
    Task<NotificationViewModel> Update(Guid id, NotificationEditModel notification);
    
    [Delete("/api/notification")]
    Task Delete(Guid id);
}