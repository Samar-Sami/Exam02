namespace ExaminationSystem
{
    public class FinalExam : ExamBase
    {
        public List<QuestionBase> Questions { get; set; }

        public FinalExam(int examDuration, int numberOfQuestions, Subject subject) 
            : base(examDuration, numberOfQuestions, subject) => Questions = new List<QuestionBase>(numberOfQuestions);


        public override void AddQuestion(QuestionBase question)
        {
            try
            {
                if (question is TrueOrFalseQuestion || question is SingleAnswerMCQQuestion)
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
            FinalExam finalExam = this;
            foreach (var question in finalExam.Questions)
            {
                question.ShowQuestion();
                question.ChosenAnswer = int.Parse(Console.ReadLine());
                if (question.ChosenAnswer == question.RightAnswerIds[0])
                {
                    ExamGrade += question.Mark;
                }
                ExamMarks += question.Mark;
            }

            Console.WriteLine($"Your answers:");
            for (int i = 0; i < finalExam.Questions.Count; i++)
            {
                Console.WriteLine($"Q{i + 1})   {finalExam.Questions[i].QuestionBody}: {finalExam.Questions[i].ChosenAnswer}");
            }
            Console.WriteLine($"Your exam grade is {ExamGrade} from {ExamMarks}");
        }
    }
}
