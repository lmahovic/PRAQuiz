namespace Web.ViewModels;

public class QuestionViewModel
{
    public QuestionViewModel()
    {
        Answers = new List<AnswerViewModel>();
    }

    public int Id { get; set; }
    public string QuestionText { get; set; } = "";
    public int TimeLimit { get; set; }
    public byte QuestionOrder { get; set; }
    public List<AnswerViewModel> Answers { get; set; }
}