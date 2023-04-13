using AutoMapper;
using OnboardingBot.Shared.EditModels;
using OnboardingBot.Shared.ViewModels;

namespace OnboardingBot.Shared;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<AnswerViewModel, AnswerEditModel>().ReverseMap();
        CreateMap<ButtonViewModel, ButtonEditModel>().ReverseMap();
        CreateMap<NotificationViewModel, NotificationEditModel>().ReverseMap();
        CreateMap<PositionViewModel, PositionEditModel>().ReverseMap();
        CreateMap<QuestionViewModel, QuestionEditModel>().ReverseMap();
        CreateMap<QuizViewModel, QuizEditModel>().ReverseMap();
        CreateMap<RoleOnboardingViewModel, RoleOnboardingEditModel>().ReverseMap();
        CreateMap<StepViewModel, StepEditModel>().ReverseMap();
        CreateMap<TestViewModel, TestEditModel>().ReverseMap();
        CreateMap<TextCommandViewModel, TextCommandEditModel>().ReverseMap();
        CreateMap<UserViewModel, UserEditModel>().ReverseMap();
        CreateMap<UserOnboardingViewModel, UserOnboardingEditModel>().ReverseMap();
        CreateMap<UserQuestionViewModel, UserQuestionEditModel>().ReverseMap();
    }
}