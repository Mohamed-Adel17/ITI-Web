using Examination_System.QuestionsAndAnswers;
using Examination_System.Exam;
using Examination_System.School;

AnswerList TrueOrFalse = new AnswerList()
{
    new Answer() { AnswerText = "True" },
    new Answer() { AnswerText = "False" }
};
var a4 = new AnswerList()
{
    new Answer() { AnswerText = "int" },
    new Answer() { AnswerText = "float" },
    new Answer() { AnswerText = "string" },
    new Answer() { AnswerText = "bool" }
};
var a5 = new AnswerList()
{
    new Answer() { AnswerText = "public" },
    new Answer() { AnswerText = "private" },
    new Answer() { AnswerText = "protected" },
    new Answer() { AnswerText = "internal" }
};
//Create some Questions 
QuestionTrueOrFalse q1 = new QuestionTrueOrFalse()
{
    Body = "The using directive is only for namespaces and cannot be used for resource disposal.",
    Marks = 1,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "False" }
    }
};
QuestionTrueOrFalse q2 = new QuestionTrueOrFalse()
{
    Body = "string in C# is immutable",
    Marks = 1,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "True" }
    }
};

QuestionChooseOne q4 = new QuestionChooseOne()
{
    Body = "Which of the following is not a value type in C#?",
    Marks = 2,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "string" }
    }
};


QuestionChooseOne q5 = new QuestionChooseOne()
{
    Body = "What is the default access modifier for class members in C#?",
    Marks = 2,
    Answers = new AnswerList()
    {
        new Answer() { AnswerText = "private" },
    }
};


QuestionList questionList = new QuestionList();
questionList.Add(q1);
questionList.Add(q2);
questionList.Add(q4);
questionList.Add(q5);
// Create an exam
FinalExam finalExam = new FinalExam(DateTime.Now, 120, 4);
finalExam.Mode = ExamMode.Starting;
finalExam.questionsAndAnswers.Add(q1, TrueOrFalse);
finalExam.questionsAndAnswers.Add(q2, TrueOrFalse);
finalExam.questionsAndAnswers.Add(q4, a4);
finalExam.questionsAndAnswers.Add(q5, a5);
finalExam.ShowExam();









