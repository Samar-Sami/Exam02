namespace ExaminationSystem
{
    public class SingleAnswerMCQQuestion : MCQQuestionBase
    {
        public SingleAnswerMCQQuestion(string questionHeader, string questionBody, int mark, Answer[] answersList, int rightAnswerId) 
            : base(questionHeader, questionBody, mark, answersList, [rightAnswerId])
        {
        }
    }
}
