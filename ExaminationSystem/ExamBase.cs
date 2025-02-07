using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class ExamBase
    {
        public int ExamDuration { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set; }
        public int ExamGrade { get; set; }
        public int ExamMarks { get; set; }

        protected ExamBase(int examDuration, int numberOfQuestions, Subject subject)
        {
            ExamDuration = examDuration;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
        }
        public abstract void ShowExam();
        public abstract void AddQuestion(QuestionBase question);
    }
}
