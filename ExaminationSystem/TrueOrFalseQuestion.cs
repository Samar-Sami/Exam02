namespace ExaminationSystem
{
    public class TrueOrFalseQuestion : QuestionBase
    {
        public TrueOrFalseQuestion(string questionHeader, string questionBody, int mark, Answer[] answersList, int rightAnswerId) 
            : base(questionHeader, questionBody, mark, answersList, [rightAnswerId])
        {
        }
        public override void ShowQuestion()
        {
            Console.WriteLine($"{QuestionHeader}\n{QuestionBody}");
            var answers = string.Empty;
            foreach (var answer in AnswersList)
            {
                answers += $"{answer.AnswerId}. {answer.AnswerText}                      ";
            }
            Console.WriteLine($"{answers}");
            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"=================================================");
        }
    }
}
