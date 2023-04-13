using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server;

public class DBContext : DbContext
{
    public DbSet<ButtonEntity> Buttons => Set<ButtonEntity>();
    public DbSet<NotificationEntity> Notifications => Set<NotificationEntity>();
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
    public DbSet<UserQuestionEntity> UserQuestions => Set<UserQuestionEntity>();

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

        modelBuilder.Entity<UserOnboardingEntity>()
            .HasKey(xx => new { xx.ID });

        modelBuilder.Entity<RoleOnboardingEntity>()
            .HasMany(x => x.Steps)
            .WithMany(x => x.RoleOnboardings)
            .UsingEntity<RoleOnboardingStepEntity>(
                x => x
                    .HasOne(m => m.Step)
                    .WithMany(m => m.RoleOnboardingPositions)
                    .HasForeignKey(m => m.StepID),
                x => x
                    .HasOne(m => m.RoleOnboarding)
                    .WithMany(m => m.StepPositions)
                    .HasForeignKey(m => m.RoleOnboardingID),
                x =>
                {
                    x.Property(t => t.Position).IsRequired();
                    x.Property(t => t.Position).HasDefaultValue(1);
                    x.HasKey(t => new { t.RoleOnboardingID, t.StepID, t.Position });
                }
            );
    }
}