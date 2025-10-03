using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class Question
    {
        public string Header { get; set;}
        public string Body {  get; set; }
        public int Marks { get; set; }
      

        public AnswerList Answers { get; set; } = new AnswerList();
        

        public Question()
        {
            
        }
        public Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
        }

    }
}
