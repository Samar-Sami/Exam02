using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public ExamBase Exam { get; set; }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }
        private void CreateExam(int examDuration, int numberOfQuestions, bool isPractical)
        {
            if (isPractical)
            {
                Exam = new PracticalExam(examDuration, numberOfQuestions, this);
            }
            else
            {
                Exam = new FinalExam(examDuration, numberOfQuestions, this);
            }
        }

        public void CreateExam()
        {
            var _isPractical = false;
            var _examDurationInMinutes = 0;
            var _noOfQuestions = 0;
            var _questionType = 0;

            Console.WriteLine($"Please enter the type of exam you want to Create (1 for Practical and 2 for final:");
            var examType = Console.ReadLine();
            if (int.TryParse(examType, out int examTypeResult))
            {
                if (examTypeResult == 1)
                    _isPractical = true;
                else if (examTypeResult == 2)
                    _isPractical = false;
            }

            Console.WriteLine($"Please enter the time of the exam in minutes:");
            var examDuration = Console.ReadLine();
            if (int.TryParse(examDuration, out int examDurationResult))
                _examDurationInMinutes = examDurationResult;


            Console.WriteLine($"Please enter the number of questions you want to create:");
            var noOfQuestions = Console.ReadLine();
            if (int.TryParse(noOfQuestions, out int noOfQuestionsResult))
                _noOfQuestions = noOfQuestionsResult;

            CreateExam(examDuration: _examDurationInMinutes, numberOfQuestions: _noOfQuestions, isPractical: _isPractical);
            Console.Clear();
            ExamBase exam;
            if (_isPractical)
            {
                exam = (PracticalExam)Exam;
                for (int i = 1; i <= _noOfQuestions; i++)
                {
                    Console.WriteLine($"Choose one answer question");
                    Console.WriteLine($"Please Enter the Body of the Question {i}:");
                    var questionBody = Console.ReadLine();
                    Console.WriteLine($"Please Enter the marks of the Question {i}:");
                    var marks = Console.ReadLine();
                    var _marks = 0;
                    if (int.TryParse(marks, out int marksResult))
                        _marks = marksResult;
                    var questionHeader = $"({i}) Choose one answer question    Mark({_marks})";
                    Console.WriteLine($"The choices of Question no. {i}:");
                    Console.WriteLine($"Please Enter the number of chocies for the Question no. {i}:");
                    var noOfAnswers = int.Parse(Console.ReadLine());
                    var answers = new Answer[noOfAnswers];
                    for (int j = 0; j < answers.Length; j++)
                    {
                        Console.WriteLine($"Please Enter the choice number {j + 1}:");
                        var answerText = Console.ReadLine();
                        var answer = new Answer(j + 1, answerText);
                        answers[j] = answer;
                    }
                    Console.WriteLine($"Please Enter the right choice of question no. {i}");
                    var rightAnswer = Console.ReadLine();
                    var _rightAnswer = int.TryParse(rightAnswer, out int rightAnswerResult);
                    var rightAnswerId = answers.Where(a => a.AnswerId == rightAnswerResult).FirstOrDefault().AnswerId;
                    var multipleAnswerMCQQuestion = new MultipleAnswerMCQQuestion(questionHeader: questionHeader, questionBody: questionBody, mark: _marks, answersList: answers, rightAnswerIds: [rightAnswerId]);
                    exam.AddQuestion(multipleAnswerMCQQuestion);
                    Console.Clear();
                }
            }
            else
            {
                exam = (FinalExam)Exam;
                for (int i = 1; i <= _noOfQuestions; i++)
                {
                    Console.WriteLine($"Please choose the type of question number({i}) (1 for True or False || 2 for MCQ):");
                    var questionType = Console.ReadLine();
                    if (int.TryParse(questionType, out int questionTypeResult))
                    {
                        if (questionTypeResult == 1)
                        {
                            Console.WriteLine($"True | False Question");
                            Console.WriteLine($"Please Enter the Body of the Question {i}:");
                            var questionBody = Console.ReadLine();
                            Console.WriteLine($"Please Enter the marks of the Question {i}:");
                            var marks = Console.ReadLine();
                            var _marks = 0;
                            if (int.TryParse(marks, out int marksResult))
                                _marks = marksResult;
                            var questionHeader = $"({i}) True | False Question    Mark({_marks})";
                            var answers = new Answer[2] { new Answer(1, "True"), new Answer(2, "False") };
                            Console.WriteLine($"Please Enter the right answer of question no. {i} (1 for True and 2 for False):");
                            var rightAnswer = Console.ReadLine();
                            var _rightAnswer = int.TryParse(rightAnswer, out int rightAnswerResult);
                            var rightAnswerId = answers.Where(a => a.AnswerId == rightAnswerResult).FirstOrDefault().AnswerId;
                            var trueOrFalseQuestion = new TrueOrFalseQuestion(questionHeader: questionHeader, questionBody: questionBody, mark: _marks, answersList: answers, rightAnswerId: rightAnswerId);
                            exam.AddQuestion(trueOrFalseQuestion);
                            Console.Clear();
                        }
                        else if (questionTypeResult == 2)
                        {
                            Console.WriteLine($"Choose one answer question");
                            Console.WriteLine($"Please Enter the Body of the Question {i}:");
                            var questionBody = Console.ReadLine();
                            Console.WriteLine($"Please Enter the marks of the Question {i}:");
                            var marks = Console.ReadLine();
                            var _marks = 0;
                            if (int.TryParse(marks, out int marksResult))
                                _marks = marksResult;
                            var questionHeader = $"({i}) Choose one answer question    Mark({_marks})";
                            Console.WriteLine($"The choices of Question no. {i}:");
                            Console.WriteLine($"Please Enter the number of chocies for the Question no. {i}:");
                            var noOfAnswers = int.Parse(Console.ReadLine());
                            var answers = new Answer[noOfAnswers];
                            for (int j = 0; j < answers.Length; j++)
                            {
                                Console.WriteLine($"Please Enter the choice number {j + 1}:");
                                var answerText = Console.ReadLine();
                                var answer = new Answer(j + 1, answerText);
                                answers[j] = answer;
                            }
                            Console.WriteLine($"Please Enter the right choice of question no. {i}");
                            var rightAnswer = Console.ReadLine();
                            var _rightAnswer = int.TryParse(rightAnswer, out int rightAnswerResult);
                            var rightAnswerId = answers.Where(a => a.AnswerId == rightAnswerResult).FirstOrDefault().AnswerId;
                            var singleAnswerMCQQuestion = new SingleAnswerMCQQuestion(questionHeader: questionHeader, questionBody: questionBody, mark: _marks, answersList: answers, rightAnswerId: rightAnswerId);
                            exam.AddQuestion(singleAnswerMCQQuestion);
                            Console.Clear();
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Subject Name: {SubjectName}";
        }
    }
}
