using System;
using System.IO;

namespace _6._1.example
{

    abstract class AbstractHandler
    {
        public abstract void Open();
        public abstract void Create();
        public abstract void Edit();

    }
    class Text : AbstractHandler
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public virtual string Extension
        {
            get
            {
                return ".txt";
            }
        }

        public override void Open()
        {
            Console.Write("Введіть назву файлу: ");
            string name = Console.ReadLine();
            string path = desktop + "/" + name + Extension;
            Console.WriteLine("Текст у файлі: ");
            string[] read = File.ReadAllLines(path);
            foreach (string s in read)
            {
                Console.WriteLine(s);
            }
        }
        public override void Create()
        {
            Console.Write("Введіть назву файлу: ");
            string name = Console.ReadLine();
            string path = desktop + "/" + name + Extension;
            Console.WriteLine("Файл створено за шляхом: " + path);
        }
        public override void Edit()
        {
            Console.Write("Введіть назву файлу: ");
            string name = Console.ReadLine();
            string path = desktop + "/" + name + Extension;
            string text;
            Console.WriteLine("Текст у файлі:");
            string[] read = File.ReadAllLines(path);
            foreach (string s in read)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
            Console.Write("Введіть текст який потрібно замінити: ");
            string oldText = Console.ReadLine();
            Console.Write("Новий текст: ");
            string newText = Console.ReadLine();

            text = File.ReadAllText(path);
            text = text.Replace(oldText, newText);
            File.WriteAllText(path, text);
        }
    }
    class Word : Text
    {
        public override string Extension
        {
            get
            {
                return ".docx";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("1 - txt");
            Console.WriteLine("2 - docx");
            Console.Write("Виберіть формат документу: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Text act;

            
            if (num1 == 1)
            {
                act = new Text();
            }
            else if (num1 == 2)
            {
                act = new Word();
            }
            else
            {
                throw new Exception("Введіть 1 або 2");
            }

            Console.WriteLine();
            Console.WriteLine("1 - Відкрити");
            Console.WriteLine("2 - Створити");
            Console.WriteLine("3 - Редагувати");
            Console.Write("Виберіть дію з документом: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            if (num2 == 1)
            {
                act.Open();
            }
            else if (num2 == 2)
            {
                act.Create();
            }
            else if (num2 == 3)
            {
                act.Edit();
            }
            else
            {
                throw new Exception("Введіть 1, 2 або 3");
            }
        }
    }
}
