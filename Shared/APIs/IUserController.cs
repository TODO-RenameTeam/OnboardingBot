using OnboardingBot.Shared.Entities;
using Refit;

namespace OnboardingBot.Server.Shared.APIs;

public interface IUserController
{
    [Get("/api/user")]
    Task<List<UserEntity>> GetAll();
    
    [Get("/api/user/{id}")]
    Task<UserEntity> GetByID(Guid id);
}