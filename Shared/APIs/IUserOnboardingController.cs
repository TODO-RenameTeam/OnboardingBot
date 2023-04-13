using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface IUserOnboardingController
{
    [Get("/api/useronboarding")]
    Task<List<UserOnboardingViewModel>> GetAll();
    
    [Get("/api/useronboarding/{id}")]
    Task<UserOnboardingViewModel> GetByID(Guid id);

    [Post("/api/useronboarding")]
    Task<UserOnboardingViewModel> Create(UserOnboardingEditModel useronboarding);
    
    [Put("/api/useronboarding")]
    Task<UserOnboardingViewModel> Update(Guid id, UserOnboardingEditModel useronboarding);
    
    [Delete("/api/useronboarding")]
    Task Delete(Guid id);
}