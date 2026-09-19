using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam.Questions
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, int choicesCount = 4)
            : base(header, body, mark, choicesCount)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body}");
            Console.WriteLine($"MCQ Question:   Mark {Mark}");

            foreach (var ans in AnswerList)
            {
                Console.WriteLine(ans);
            }
        }
    }
}
