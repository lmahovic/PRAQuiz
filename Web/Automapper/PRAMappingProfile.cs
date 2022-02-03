using AutoMapper;
using Web.Entities;
using Web.ViewModels;

namespace Web.Automapper;

public class PraMappingProfile : Profile
{
    public PraMappingProfile()
    {
        CreateMap<Game, GameViewModel>();
        CreateMap<Player, PlayerViewModel>()
            .ReverseMap();
        CreateMap<Question, QuestionViewModel>()
            .ReverseMap();
        CreateMap<Answer, AnswerViewModel>()
            .ReverseMap();
        CreateMap<PlayerQuestionAnswer, PlayerQuestionAnswerViewModel>()
            .ReverseMap();
        CreateMap<PlayerRanking, PlayerRankingViewModel>()
            .ReverseMap();

        CreateMap<Author, AuthorViewModel>().ReverseMap();
        CreateMap<Quiz, QuizViewModel>().ReverseMap();
    }
}