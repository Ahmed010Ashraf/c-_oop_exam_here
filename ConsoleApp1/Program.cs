using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{

    public class Answers
    {
        public string? ans { get; set; }
        public int ans_id { get; set; }
    }

    public class Qustion
    {
        public string? header { get; set; }
        public string? body { get; set; }
        public int mark { get; set; }
        public Answers[]? answers { get; set; }
        public int rightanswerid { get; set; }
    }

    public class MCQ : Qustion
    {

    }
    public class TandF : Qustion
    {

    }
    public class Exam
    {
        public decimal time { get; set; }
        public int extype { get; set; }
        public int numOfQustions { get; set; }
        public int counter { get; set; }
        public Exam()
        {
            counter = 0;
        }
        public Qustion[]? q { get; set; }
        public void showexam()
        {
            int len = this?.q?.Length ?? 0;
            if (this is not null)
            {
                for (int i = 0; i < len; i++)
                {
                    Console.WriteLine(this?.q?[i].header);
                    int anslen = this?.q?[i]?.answers?.Length ?? 0;
                    for (int j = 0; j < anslen; j++)
                    {
                        Console.WriteLine($"{this?.q?[i]?.answers?[j].ans_id}){this?.q?[i]?.answers?[j].ans}");
                    }
                    int useranswer;
                    bool fflag = false;
                    do
                    {
                        Console.WriteLine("enter your answer number");
                        fflag = int.TryParse(Console.ReadLine(), out useranswer);
                    } while (!fflag);
                    if (useranswer == this?.q?[i].rightanswerid)
                    {
                        counter++;
                    }

                }

                Console.WriteLine($"your grade is {counter} from {this?.q?.Length}");
                if (this.extype == 1)
                {
                    for (int i = 0; i < len; i++)
                    {
                        Console.WriteLine($"the qustion {this?.q?[i].header} :");


                        Console.WriteLine($"the correct answer is {this?.q?[i].rightanswerid}");
                        Console.WriteLine();

                    }
                }
            }

        }
    }

    public class Subject
    {
        public int subjectid { get; set; }
        public int counter { get; set; }
        public Subject()
        {
            counter = 0;
            exam = new Exam();
        }
        public string? name { get; set; }
        public Exam? exam { get; set; }
        public void implementexam()
        {
            Console.WriteLine("1-)final or 2-)parctical");
            bool flag = false;
            int Texam;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out Texam);
            } while (!flag);

            if (Texam == 1)
            {
               if(exam != null)
                {
                    exam.extype = 1;
                }
                int time;
                int numofqustions;
                bool f;
                do
                {
                    Console.WriteLine("enter correct time");
                    f = int.TryParse(Console.ReadLine(), out time);

                    Console.WriteLine("enter correct number of qustions");
                    f = int.TryParse(Console.ReadLine(), out numofqustions);
                } while (!f);
                Console.WriteLine("do you want 1)mcq or 2)t&f");
                bool x = int.TryParse(Console.ReadLine(), out int z);
                if(exam != null)
                {
                    exam.time = time;
                    exam.numOfQustions = numofqustions;
                    exam.q = new Qustion[numofqustions];
                }

                if(exam != null)
                {
                    exam.q = new Qustion[numofqustions];
                }
                
                for (int i = 0; i < numofqustions; i++)
                {
                    exam.q[i] = new Qustion();
                    Console.WriteLine("enter the qustion : ");
                    if (exam?.q?[i] != null)
                    {
                        exam.q[i].header = Console.ReadLine();
                    }
                    Console.WriteLine("enter the num of answers");
                    int numofanswers;
                    bool tflag;
                    do
                    {
                        tflag = int.TryParse(Console.ReadLine(), out numofanswers);
                    } while (!tflag);

                    if(exam?.q?[i] != null)
                    {
                        exam.q[i].answers = new Answers[numofanswers];
                    }

                    for (int j = 0; j < numofanswers; j++)
                    {
                        exam.q[i].answers[j] = new Answers();

                        if (exam?.q?[i].answers?[j] != null)
                        {
                            exam.q[i].answers[j].ans = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("One of them is null");
                        }


                        if(exam?.q?[i].answers?[j] != null)
                        {
                            exam.q[i].answers[j].ans_id = j + 1;
                        }
                        else
                        {
                            Console.WriteLine("One of them is null");
                        }
                    }
                    Console.WriteLine("enter the number of right answer");
                    int rightanswer;
                    bool aflag;
                    do
                    {
                        aflag = int.TryParse(Console.ReadLine(), out rightanswer);
                    } while (!aflag);
                    if(exam?.q?[i] != null)
                    {
                        exam.q[i].rightanswerid = rightanswer;
                    }




                }

            }
            else
            {
                if (exam != null)
                {
                    exam.extype = 2;
                }

                int time;
                int numofqustions;
                bool f;
                do
                {
                    Console.WriteLine("enter correct time");
                    f = int.TryParse(Console.ReadLine(), out time);

                    Console.WriteLine("enter correct number of qustions");
                    f = int.TryParse(Console.ReadLine(), out numofqustions);
                } while (!f);
                
                if (exam != null)
                {
                    exam.time = time;
                    exam.numOfQustions = numofqustions;
                    exam.q = new Qustion[numofqustions];
                }

                if (exam != null)
                {
                    exam.q = new Qustion[numofqustions];
                }

                for (int i = 0; i < numofqustions; i++)
                {
                    exam.q[i] = new Qustion();
                    Console.WriteLine("enter the qustion : ");
                    if (exam?.q?[i] != null)
                    {
                        exam.q[i].header = Console.ReadLine();
                    }
                    Console.WriteLine("enter the num of answers");
                    int numofanswers;
                    bool tflag;
                    do
                    {
                        tflag = int.TryParse(Console.ReadLine(), out numofanswers);
                    } while (!tflag);

                    if (exam?.q?[i] != null)
                    {
                        exam.q[i].answers = new Answers[numofanswers];
                    }

                    for (int j = 0; j < numofanswers; j++)
                    {
                        exam.q[i].answers[j] = new Answers();

                        if (exam?.q?[i].answers?[j] != null)
                        {
                            exam.q[i].answers[j].ans = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("One of them is null");
                        }


                        if (exam?.q?[i].answers?[j] != null)
                        {
                            exam.q[i].answers[j].ans_id = j + 1;
                        }
                        else
                        {
                            Console.WriteLine("One of them is null");
                        }
                    }
                    Console.WriteLine("enter the number of right answer");
                    int rightanswer;
                    bool aflag;
                    do
                    {
                        aflag = int.TryParse(Console.ReadLine(), out rightanswer);
                    } while (!aflag);
                    if (exam?.q?[i] != null)
                    {
                        exam.q[i].rightanswerid = rightanswer;
                    }




                }
            }
        }
    }
        internal class Program
        {
            static void Main()
            {
            Subject sb = new Subject();
            sb?.implementexam();
            Console.WriteLine("do you wnat to display the exam : 1)yes or 2)no ");
            int im;
            bool test;
            do
            {
                test = int.TryParse(Console.ReadLine(), out im );
            } while (!test);

            if(im == 1)
            {
                sb?.exam?.showexam();
            }
            }
        }
    
}
