using Examination_System.QuestionsAndAnswers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
    enum ExamMode
    {
        None,
        Starting,
        Queued,
        Finished
    }
    internal abstract class Exam
    {
        DateTime date;
        int duration; // in minutes
        int numberOfQuestions;
        Enum mode = ExamMode.None;
        protected int studentMarks = 0;
        public Dictionary<Question, AnswerList> questionsAndAnswers = new Dictionary<Question, AnswerList>();

        public Exam(DateTime date, int duration, int numberOfQuestions)
        {
            this.Date = date;
            this.Duration = duration;
            this.NumberOfQuestions = numberOfQuestions;
        }

        public int Duration { get => duration; set => duration = value; }
        public int NumberOfQuestions { get => numberOfQuestions; set => numberOfQuestions = value; }
        public DateTime Date { get => date; set => date = value; }
        public Enum Mode { get => mode; set => mode = value; }

        public abstract void ShowExam();

        protected void EvaluateStudentAnswer(Question question, AnswerList studentAnswer)
        {
            bool isCorrect = true;
            if (studentAnswer.Count != question.Answers.Count)
            {
                isCorrect = false;
            }
            else
            {
                foreach (var ans in question.Answers)
                {
                    if (!studentAnswer.Any(a => a.AnswerText == ans.AnswerText))
                    {
                        isCorrect = false;
                        break;
                    }
                }
            }
            if (isCorrect)
            {
                studentMarks += question.Marks;
                //Console.WriteLine("Correct Answer! +" + question.Marks + " Marks");
            }
            else
            {
                //Console.WriteLine("Wrong Answer! +0 Marks");
            }
        }
    }

}
