using AutoMapper;
using OnboardingBot.Server.Entities;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Server;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<AnswerViewModel, AnswerEditModel>().ReverseMap();
        CreateMap<AnswerViewModel, AnswerEntity>().ReverseMap();
        CreateMap<AnswerEditModel, AnswerEntity>().ReverseMap();

        CreateMap<ButtonViewModel, ButtonEditModel>().ReverseMap();
        CreateMap<ButtonViewModel, ButtonEntity>().ReverseMap();
        CreateMap<ButtonEditModel, ButtonEntity>().ReverseMap();

        CreateMap<PositionViewModel, PositionEditModel>().ReverseMap();
        CreateMap<PositionViewModel, PositionEntity>().ReverseMap();
        CreateMap<PositionEditModel, PositionEntity>().ReverseMap();

        CreateMap<QuestionViewModel, QuestionEditModel>().ReverseMap();
        CreateMap<QuestionViewModel, QuestionEntity>().ReverseMap();
        CreateMap<QuestionEditModel, QuestionEntity>().ReverseMap();

        CreateMap<QuizViewModel, QuizEditModel>().ReverseMap();
        CreateMap<QuizViewModel, QuizEntity>().ReverseMap();
        CreateMap<QuizEditModel, QuizEntity>().ReverseMap();

        CreateMap<RoleOnboardingViewModel, RoleOnboardingEditModel>().ReverseMap();
        CreateMap<RoleOnboardingViewModel, RoleOnboardingEntity>().ReverseMap();
        CreateMap<RoleOnboardingEditModel, RoleOnboardingEntity>().ReverseMap();

        CreateMap<StepViewModel, StepEditModel>().ReverseMap();
        CreateMap<StepViewModel, StepEntity>().ReverseMap();
        CreateMap<StepEditModel, StepEntity>().ReverseMap();

        CreateMap<TelegramCodeViewModel, TelegramCodeEntity>().ReverseMap();

        CreateMap<TestViewModel, TestEditModel>().ReverseMap();
        CreateMap<TestViewModel, TestEntity>().ReverseMap();
        CreateMap<TestEditModel, TestEntity>().ReverseMap();

        CreateMap<TextCommandViewModel, TextCommandEditModel>().ReverseMap();
        CreateMap<TextCommandViewModel, TextCommandEntity>().ReverseMap();
        CreateMap<TextCommandEditModel, TextCommandEntity>().ReverseMap();

        CreateMap<UserAnswerViewModel, UserAnswerEntity>().ReverseMap();

        CreateMap<UserOnboardingViewModel, UserOnboardingEditModel>().ReverseMap();
        CreateMap<UserOnboardingViewModel, UserOnboardingEntity>().ReverseMap();
        CreateMap<UserOnboardingEditModel, UserOnboardingEntity>().ReverseMap();

        CreateMap<UserTestAnswerViewModel, UserTestAnswerEntity>().ReverseMap();

        CreateMap<UserViewModel, UserEditModel>().ReverseMap();
        CreateMap<UserViewModel, UserEntity>().ReverseMap();
        CreateMap<UserEditModel, UserEntity>().ReverseMap();
    }
}