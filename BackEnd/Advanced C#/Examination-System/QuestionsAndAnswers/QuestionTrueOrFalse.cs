using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class QuestionTrueOrFalse : Question
    {
        
        public QuestionTrueOrFalse() : base()
        {
            Header = $"Choose either True or False.";
            
        }
        public QuestionTrueOrFalse(string header, string body, int marks) : base(header, body, marks)
        {
            
        }

    }
}
