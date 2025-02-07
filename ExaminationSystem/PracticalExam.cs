namespace ExaminationSystem
{
    public class PracticalExam : ExamBase
    {
        public List<QuestionBase> Questions { get; set; }
        public PracticalExam(int examDuration, int numberOfQuestions, Subject subject) 
            : base(examDuration, numberOfQuestions, subject) => Questions = new List<QuestionBase>(numberOfQuestions);

        public override void AddQuestion(QuestionBase question)
        {
            try
            {
                if (question is MultipleAnswerMCQQuestion)
                {
                    Questions.Add(question);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Cannot add more than {NumberOfQuestions} questions. The limit has been reached.");
            }
            
        }

        public override void ShowExam()
        {
            PracticalExam practicalExam = this;
            foreach (var question in practicalExam.Questions)
            {
                question.ShowQuestion();
                question.ChosenAnswer = int.Parse(Console.ReadLine());
                if (question.ChosenAnswer == question.RightAnswerIds[0])
                {
                    ExamGrade += question.Mark;
                }
                ExamMarks += question.Mark;
            }
            Console.Clear();
            Console.WriteLine($"Your answers:");
            for (int i = 0; i < practicalExam.Questions.Count; i++)
            {
                Console.WriteLine($"Q{i + 1})   {practicalExam.Questions[i].QuestionBody}: {practicalExam.Questions[i].ChosenAnswer}");
            }
            Console.WriteLine($"Your exam grade is {ExamGrade} from {ExamMarks}");
        }
    }
}
