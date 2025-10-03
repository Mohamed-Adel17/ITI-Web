using Examination_System.QuestionsAndAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
    internal class FinalExam : Exam
    {
        public FinalExam(DateTime date, int duration, int numberOfQuestions) : base(date, duration, numberOfQuestions)
        {
        }
        public override void ShowExam()
        {
            int qCounter = 1;
            foreach (var item in questionsAndAnswers)
            {
                Console.WriteLine($"Q{qCounter++}: {item.Key.Header}\n{item.Key.Body}\nMarks: {item.Key.Marks}");
                int answerNumber = 1;
                foreach (var _answer in item.Value)
                {
                    Console.WriteLine($"{answerNumber++}: {_answer.AnswerText}");
                }
                Console.WriteLine();
                Console.Write($"Your Choice: ");
                var answer = Console.ReadLine()
                .Split(',')
                .Select(s => s.Trim())     
                .Where(s => s != "")       
                .Select(int.Parse)         
                .ToList();
                AnswerList studentAnswer = new AnswerList();
                foreach (var ans in answer)
                {
                    if (ans > 0 && ans <= item.Value.Count)
                        studentAnswer.Add(item.Value[ans - 1]);
                }
                EvaluateStudentAnswer(item.Key, studentAnswer);
                Console.WriteLine("-------------------------------------");

            }
            Console.WriteLine($"Your Total Marks: {studentMarks}");
        }
    }
}
