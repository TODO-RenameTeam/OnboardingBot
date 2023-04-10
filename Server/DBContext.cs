using Microsoft.EntityFrameworkCore;
using OnboardingBot.Shared.Entities;

namespace OnboardingBot.Server;

public class DBContext : DbContext
{
    public DbSet<ButtonEntity> Buttons => Set<ButtonEntity>();
    public DbSet<PositionEntity> Positions => Set<PositionEntity>();
    public DbSet<QuestionEntity> Questions => Set<QuestionEntity>();
    public DbSet<TestEntity> Tests => Set<TestEntity>();
    public DbSet<TelegramCodeEntity> TelegramCodes => Set<TelegramCodeEntity>();
    public DbSet<TextCommandEntity> TextCommands => Set<TextCommandEntity>();
    public DbSet<UserTestAnswerEntity> UserTestAnswers => Set<UserTestAnswerEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    
    public DBContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}