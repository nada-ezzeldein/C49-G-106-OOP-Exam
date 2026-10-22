namespace OOP_Exam
{
    class Question
    {
        public string Header;
        public string Body;
        public int Mark;

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }   

        public virtual void Display()
        {
            Console.WriteLine($"Header: {Header}");
            Console.WriteLine($"Body: {Body}");
            Console.WriteLine($"Mark: {Mark}");
        }
    }

    class TrueFalseQuestion : Question
    {
        public bool Answer;
        public TrueFalseQuestion(string header, string body, int mark, bool answer)
            : base(header, body, mark)
        {
            Answer = answer;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Answer: {Answer}");
        }
    }

    class MCQQuestion : Question
    {
        public string[] Options;
        public MCQQuestion(string header, string body, int mark, string[] options)
            : base(header, body, mark)
        {
            Options = options;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Options:");
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
        }
    }

    class FinalExam
    {
        public Question[] Questions;
        public FinalExam(Question[] questions)
        {
            Questions = questions;
        }
        public void ShowExam()
        {
           foreach ( Question q in Questions)
            {
                q.Display();
                Console.WriteLine();
            }
        }
        public void Display()
        {
            foreach (var question in Questions)
            {
                question.Display();
                Console.WriteLine();
            }
        }
    }

    class PracticalExam
    {
        public MCQQuestion[] Questions;
        public PracticalExam(MCQQuestion[] questions)
        {
            Questions = questions;
        }
        public void ShowExam()
        {
            foreach (MCQQuestion q in Questions)
            {
                q.Display();
                Console.WriteLine();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
