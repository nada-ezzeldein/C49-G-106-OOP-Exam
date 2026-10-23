namespace OOP_Exam
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public Answer RightAnswer { get; set; }
        public Question(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            RightAnswer = rightAnswer;
        }

        public abstract void showQuestion();
        
    }

    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
            : base(header, body, mark, answers, rightAnswer)
        {
        }
        public override void showQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            foreach (Answer answer in Answers)
            {
                Console.WriteLine($" {answer.AnswerID})  {answer.AnswerText}");
            }
        }
    }

    class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
            : base(header, body, mark, answers, rightAnswer)
        {
        }
        public override void showQuestion()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            foreach (Answer answer in Answers)
            {
                Console.WriteLine($" {answer.AnswerID})  {answer.AnswerText}");
            }
        }
    }

   public abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }

        public Exam(int time, int numberOfQuestions, Question[] questions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }

        public abstract void ShowExam();
    }

   public class FinalExam: Exam
    {
        public FinalExam(int time, int numberOfQuestions, Question[] questions): base(time, numberOfQuestions, questions)
        {
        }
        public override void ShowExam()
        {
            Console.WriteLine("Final Exam");
            Console.WriteLine($"Exam Time: {Time} minutes");
            Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
            Console.WriteLine();

            int totalGrade = 0; 
            foreach (Question question in Questions) 
            {
                question.showQuestion(); 
                Console.WriteLine($"Mark: {question.Mark}"); 
                Console.WriteLine($"Right Answer: {question.RightAnswer.AnswerText}"); 
                Console.WriteLine(); totalGrade += question.Mark; 
            }
            Console.WriteLine($"Total Grade: {totalGrade}");
        }
    }

   public class PracticalExam: Exam
    {
        public PracticalExam(int time, int numberOfQuestions, Question[] questions): base(time, numberOfQuestions, questions)
        {
        }
        public override void ShowExam()
        {
            Console.WriteLine("Practical Exam");
            Console.WriteLine($"Exam Time: {Time} minutes"); 
            Console.WriteLine($"Number of Questions: {NumberOfQuestions}"); 
            Console.WriteLine();

            foreach (Question question in Questions) {
                question.showQuestion(); 
                Console.WriteLine(); 
            }

            Console.WriteLine("RIGHT ANSWERS:"); 
            foreach (Question question in Questions) 
            {
                Console.WriteLine($"{question.Header}: {question.RightAnswer.AnswerText}");
            }
        }
    }
    
   public class Answer
    {
       public int AnswerID { get; set;}
       public string AnswerText { get; set; }
       public Answer(int id , string text)
        {
            AnswerID = id;
            AnswerText = text;
        }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        public Subject(int id, string name)
        { 
            SubjectId = id; SubjectName = name;
        }
        public void CreateExam(Exam exam) { 
            Exam = exam; 
        }

        public void ShowSubjectExam() { 
            Console.WriteLine($"Subject ID: {SubjectId}"); 
            Console.WriteLine($"Subject Name: {SubjectName}"); 
            if (Exam != null) 
            { 
                Exam.ShowExam();
            }
            else { 
                Console.WriteLine("No exam has been created yet."); 
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Answer[] tfAnswers =
                {
                new Answer(1, "True"), new Answer(2, "False")
            };
            Answer[] mcqAnswers = 
                {
                new Answer(1, "Elhadaba"), new Answer(2, "El Ostora"), new Answer(3, "El gayar"), new Answer(4, "6767") 
            };
            Question q1 = new TrueFalseQuestion("Question 1", "Hl Yogad 7ob fe klb fesal?", 5, tfAnswers, tfAnswers[0]);
            Question q2 = new MCQQuestion("Question 2", "Akl Ahmed Eltofa. Km Nesbet ElAmla7 fe Elba7r Elmotawaset?", 10, mcqAnswers, mcqAnswers[2]);
            Question[] questions = { q1, q2 };
            Subject subject = new Subject(1, "General Knowledge");
            Exam finalExam = new FinalExam(60, questions.Length, questions);
            subject.CreateExam(finalExam);
            subject.ShowSubjectExam();
        }
    }
}
