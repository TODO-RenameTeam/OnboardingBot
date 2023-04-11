using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface IUserController
{
    [Get("/api/user")]
    Task<List<UserViewModel>> GetAll();
    
    [Get("/api/user/{id}")]
    Task<UserViewModel> GetByID(Guid id);
}