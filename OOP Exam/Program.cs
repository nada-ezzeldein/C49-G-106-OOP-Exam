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

  

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
