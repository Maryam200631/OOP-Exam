using System;

namespace OOP_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub = new Subject(10, "C# Programming");
            sub.CreateExam();

            Console.Clear();
            Console.Write("Do You Want To Start Exam (Y | N): ");
            char choice = char.Parse(Console.ReadLine());

            if (char.ToUpper(choice) == 'Y')
            {
                Console.Clear();
                sub.SubjectExam.ShowExam();
            }
        }
    }
}