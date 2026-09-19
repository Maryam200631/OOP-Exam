using System;
using OOP_Exam.Exams;
using OOP_Exam.Questions;

namespace OOP_Exam
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            int examType;
            while (true)
            {
                Console.Write("Enter the type of exam (1 for Practical, 2 for Final): ");
                if (int.TryParse(Console.ReadLine(), out examType) && (examType == 1 || examType == 2))
                    break;
                Console.WriteLine("Invalid choice! Enter 1 or 2.");
            }

            int time;
            while (true)
            {
                Console.Write("Enter the time for the exam (30 to 180 minutes): ");
                if (int.TryParse(Console.ReadLine(), out time) && time >= 30 && time <= 180)
                    break;
                Console.WriteLine("Invalid time! Must be between 30 and 180.");
            }

            int numQuestions;
            while (true)
            {
                Console.Write("Enter the number of questions: ");
                if (int.TryParse(Console.ReadLine(), out numQuestions) && numQuestions > 0)
                    break;
                Console.WriteLine("Invalid number! Enter a positive integer.");
            }

            if (examType == 1)
                SubjectExam = new PracticalExam(time, numQuestions);
            else
                SubjectExam = new FinalExam(time, numQuestions);

            for (int i = 0; i < numQuestions; i++)
            {
                int qType = 1;
                if (examType == 2)
                {
                    while (true)
                    {
                        Console.Write($"Choose the type of question {i + 1} (1 for MCQ, 2 for True/False): ");
                        if (int.TryParse(Console.ReadLine(), out qType) && (qType == 1 || qType == 2))
                            break;
                        Console.WriteLine("Invalid choice! Enter 1 or 2.");
                    }
                }

                Console.WriteLine("Enter the question body:");
                string body = Console.ReadLine();

                int mark;
                while (true)
                {
                    Console.Write("Enter the question mark: ");
                    if (int.TryParse(Console.ReadLine(), out mark) && mark > 0)
                        break;
                    Console.WriteLine("Invalid input! Enter a valid positive number.");
                }

                if (qType == 1)
                {
                    var mcq = new MCQQuestion($"Question {i + 1}", body, mark, 4);
                    Console.WriteLine("Choices of Question:");
                    for (int c = 0; c < 4; c++)
                    {
                        Console.Write($"Enter choice number {c + 1}: ");
                        string choiceText = Console.ReadLine();
                        mcq.AnswerList[c] = new Answer(c + 1, choiceText);
                    }

                    int rightId;
                    while (true)
                    {
                        Console.Write("Enter the ID of the correct answer (1 to 4): ");
                        if (int.TryParse(Console.ReadLine(), out rightId) && rightId >= 1 && rightId <= 4)
                            break;
                        Console.WriteLine("Invalid ID! You must enter a number from 1 to 4.");
                    }

                    mcq.RightAnswer = mcq.AnswerList[rightId - 1];
                    SubjectExam.Questions[i] = mcq;
                }
                else
                {
                    var tf = new TorFQuestion($"Question {i + 1}", body, mark);
                    int rightId;
                    while (true)
                    {
                        Console.Write("Enter the ID of the correct answer (1 for True, 2 for False): ");
                        if (int.TryParse(Console.ReadLine(), out rightId) && (rightId == 1 || rightId == 2))
                            break;
                        Console.WriteLine("Invalid ID! Enter 1 for True or 2 for False.");
                    }

                    tf.RightAnswer = tf.AnswerList[rightId - 1];
                    SubjectExam.Questions[i] = tf;
                }
            }
        }
    }
}