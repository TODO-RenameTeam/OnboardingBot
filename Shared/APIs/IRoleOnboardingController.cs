using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;
using Refit;

namespace OnboardingBot.Shared.APIs;

public interface IRoleOnboardingController
{
    [Get("/api/roleonboarding")]
    Task<List<RoleOnboardingViewModel>> GetAll();
    
    [Get("/api/roleonboarding/{id}")]
    Task<RoleOnboardingViewModel> GetByID(Guid id);

    [Post("/api/roleonboarding")]
    Task<RoleOnboardingViewModel> Create(RoleOnboardingEditModel roleonboarding);
    
    [Put("/api/roleonboarding")]
    Task<RoleOnboardingViewModel> Update(Guid id, RoleOnboardingEditModel roleonboarding);
    
    [Delete("/api/roleonboarding")]
    Task Delete(Guid id);
}