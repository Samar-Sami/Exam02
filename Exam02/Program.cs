using ExaminationSystem;
using System.Diagnostics;

Subject Sub1 = new Subject(10, "C#");
Sub1.CreateExam();

Console.Clear();
Console.WriteLine($"Do you want to stat the exam (y | n):");

if (char.Parse(Console.ReadLine()) == 'y')
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    Sub1.Exam.ShowExam();
    stopwatch.Stop();
    Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.Minutes} minutes and {stopwatch.Elapsed.Seconds} seconds");
}
else
{
    Environment.Exit(0);
}












