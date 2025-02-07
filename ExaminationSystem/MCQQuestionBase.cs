namespace ExaminationSystem
{
    public abstract class MCQQuestionBase : QuestionBase
    {
        protected MCQQuestionBase(string qustionHeader, string questionBody, int mark, Answer[] answersList, int[] rightAnswerIds)
            : base(qustionHeader, questionBody, mark, answersList, rightAnswerIds)
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
