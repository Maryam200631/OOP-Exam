using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OOP_Exam.Exams
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].Display();

                int userChoice;
                do
                {
                    Console.Write("Enter your answer ID: ");
                } while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > Questions[i].AnswerList.Length);

                Questions[i].UserAnswer = Questions[i].AnswerList[userChoice - 1];
                Console.WriteLine();
            }

            sw.Stop();
            Console.Clear();

            Console.WriteLine("Final Exam Results:");
            int grade = 0;
            int totalGrade = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                totalGrade += Questions[i].Mark;

                if (Questions[i].UserAnswer.AnswerId == Questions[i].RightAnswer.AnswerId)
                {
                    grade += Questions[i].Mark;
                }

                Console.WriteLine($"{Questions[i].Header}: {Questions[i].Body}");
                Console.WriteLine($"Your Answer => {Questions[i].UserAnswer.AnswerText}");
                Console.WriteLine($"Correct Answer => {Questions[i].RightAnswer.AnswerText}\n");
            }

            Console.WriteLine($"Your Grade is {grade} from {totalGrade}");
            Console.WriteLine($"Time = {sw.Elapsed}");
            Console.WriteLine("Thank you");
        }
    }
}
