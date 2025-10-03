using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class Answer
    {
        string answerText="";
        public string AnswerText 
        { 
            get { return answerText; } 
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Answer text cannot be null or empty.");
                }
                answerText = value; 
            }
        }

    }
    internal class AnswerList : List<Answer>
    {
        public AnswerList() : base()
        {
        }
        public new void Add(Answer answer)
        {
            if (answer == null)
            {
                throw new ArgumentNullException(nameof(answer), "Answer cannot be null.");
            }
            base.Add(answer);
        }
    }
}
