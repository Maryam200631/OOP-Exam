using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam.Questions
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }  
        public Answer RightAnswer { get; set; }  
        public Answer UserAnswer { get; set; }

        public Question(string header, string body, int mark, int answersCount)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new Answer[answersCount];
        }

        public abstract void Display();

        public override string ToString()
        {
            return $"{Header}\n{Body}\tMark: {Mark}";
        }
    }
}
