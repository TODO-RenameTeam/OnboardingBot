using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnboardingBot.Server.Entities;

namespace OnboardingBot.Server;

public class DBContext : DbContext
{
    public DbSet<ButtonEntity> Buttons => Set<ButtonEntity>();
    public DbSet<PositionEntity> Positions => Set<PositionEntity>();
    public DbSet<QuestionEntity> Questions => Set<QuestionEntity>();
    public DbSet<QuizEntity> Quizes => Set<QuizEntity>();
    public DbSet<RoleOnboardingEntity> RoleOnboardings => Set<RoleOnboardingEntity>();
    public DbSet<StepEntity> Steps => Set<StepEntity>();
    public DbSet<TelegramCodeEntity> TelegramCodes => Set<TelegramCodeEntity>();
    public DbSet<TestEntity> Tests => Set<TestEntity>();
    public DbSet<TextCommandEntity> TextCommands => Set<TextCommandEntity>();
    public DbSet<UserTestAnswerEntity> UserTestAnswers => Set<UserTestAnswerEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<UserOnboardingEntity> UserOnboardings => Set<UserOnboardingEntity>();

    public DBContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var splitStringConverter =
            new ValueConverter<HashSet<string>, string>(v => string.Join(";", v),
                v => v.Split(new[] { ';' }).ToHashSet());
        
        modelBuilder.Entity<TextCommandEntity>()
            .Property(nameof(TextCommandEntity.Images))
            .HasConversion(splitStringConverter);
        
        modelBuilder.Entity<TextCommandEntity>()
            .Property(nameof(TextCommandEntity.Urls))
            .HasConversion(splitStringConverter);
        
        modelBuilder.Entity<StepEntity>()
            .Property(nameof(StepEntity.Images))
            .HasConversion(splitStringConverter);
        
        modelBuilder.Entity<StepEntity>()
            .Property(nameof(StepEntity.Urls))
            .HasConversion(splitStringConverter);
    }
}