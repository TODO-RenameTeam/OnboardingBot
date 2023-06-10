using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface IUserController
{
    [Get("/api/user")]
    Task<List<UserViewModel>> GetAll();
    
    [Get("/api/user/{id}")]
    Task<UserViewModel> GetByID(Guid id);
    
    [Get("/api/user/tg")]
    Task<UserViewModel> GetByTelegramID(long id);

    [Post("/api/user")]
    Task<UserViewModel> Create(UserEditModel user);
    
    [Post("/api/user/message")]
    Task SentMessage(Guid id, string text);
    
    [Put("/api/user")]
    Task<UserViewModel> Update(Guid id, UserEditModel user);
    
    [Delete("/api/user")]
    Task Delete(Guid id);
}