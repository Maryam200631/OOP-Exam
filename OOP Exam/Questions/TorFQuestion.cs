using System;
using System.Collections.Generic;
using System.Text;


namespace OOP_Exam.Questions
{
    internal class TorFQuestion : Question
    {
        public TorFQuestion(string header, string body, int mark) : base(header, body, mark, 2)
        {
            AnswerList[0] = new Answer(1, "True");
            AnswerList[1] = new Answer(2, "False");
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body}");
            Console.WriteLine($"True/False Question:   Mark {Mark}");
            foreach (var ans in AnswerList)
            {
                Console.WriteLine(ans);
            }
        }
    }
}
