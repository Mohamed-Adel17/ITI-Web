using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.QuestionsAndAnswers
{
    internal class QuestionList : List<Question>
    {
        string filePath;
        public QuestionList() : base()
        {
            filePath = $"questions_{DateTime.Now.Ticks}.txt";
            // Load from file
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 3 && int.TryParse(parts[2], out int marks))
                        {
                            this.Add(new Question(parts[0], parts[1], marks));
                        }
                    }
                }
            }
        }
        public new void Add(Question question)
        {
            base.Add(question);
            // Save to file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{question.Header}|{question.Body}|{question.Marks}");
            }
        }
    }
}
