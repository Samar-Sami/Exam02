namespace ExaminationSystem
{
    public class MultipleAnswerMCQQuestion : MCQQuestionBase
    {
        public MultipleAnswerMCQQuestion(string questionHeader, string questionBody, int mark, Answer[] answersList, int[] rightAnswerIds) 
            : base(questionHeader, questionBody, mark, answersList, rightAnswerIds)
        {
        }
    }
}
