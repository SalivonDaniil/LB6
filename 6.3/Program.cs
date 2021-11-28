using System;

namespace _6._3
{
    interface IPoints
    {
        
        void Check(int points);
    }
    abstract class Employee
    {
        public string Name;
        public string Position;
        public abstract void GetInfo();
        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }
    }
    class Worker : Employee, IPoints
    {
        private string _result;
        public string result
        {
            get
            {
                return _result;
            }
             set
            {
                this._result = value;
            }
        }
        public Worker(string name, string position) : base(name, position)
        {

        }
        public void Check(int points)
        {
            if(points > 50)
            {
                result = "Перевірка пройдена";
            }
            else
            {
                result = "Перевірка не пройдена";
            }
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Працівник №2\nІм'я: {Name}\nПосада: {Position}\nРезультат: {result}");
        }

    }
    class Examinator : Employee
    {
        public Examinator(string name, string position) : base(name, position)
        {
            
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Працівник №1\nІм'я: {Name}\nПосада: {Position}"); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Examinator examinator = new Examinator("Дмитро", "Екзамінатор");
            examinator.GetInfo();

            Console.WriteLine();

            Worker worker = new Worker("Володимир", "Системний адміністратор");
            worker.Check(60);
            worker.GetInfo();
        }
    }
}
