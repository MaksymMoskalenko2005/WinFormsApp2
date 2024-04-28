using System.Windows.Forms;

namespace WinFormsApp2
{
    public class Worker
    {

        public string name;
        public int salary;
        public string position;
        public int exp;
        public Worker(string name, int salary, string position, int exp)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.exp = exp;
        }
    }
    public class SortMethod
    {
        public static List<Worker> Salary1(List<Worker> workers)
        {
            return workers.OrderBy(worker => worker.salary).ToList();
        }
        public static List<Worker> Name1(List<Worker> workers)
        {
            return workers.OrderBy(worker => worker.name.Split(' ')[0]).ToList();
        }
        public static List<Worker> Exp1(List<Worker> workers)
        {
            return workers.OrderBy(worker => worker.exp).ToList();
        }


        public static List<Worker> Salary2(List<Worker> workers)
        {
            return workers.OrderByDescending(worker => worker.salary).ToList();
        }
        public static List<Worker> Name2(List<Worker> workers)
        {
            return workers.OrderByDescending(worker => worker.name.Split(' ')[0]).ToList();
        }
        public static List<Worker> Exp2(List<Worker> workers)
        {
            return workers.OrderByDescending(worker => worker.exp).ToList();
        }
    }
    public class Display
    {
        public static void Refresh(List<Worker> workers, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (Worker worker in workers)
            {
                listBox.Items.Add(worker.name + "\t\t" + worker.salary + "\t\t" + worker.position + "\t\t" + worker.exp);
            }
        }

    }
    public class DataBase
    {
        public DataBase(List<Worker>workers, ListBox listBox1)
        {
            AddWorker(workers, "Іваненко Іван", 5000, "Менеджер", 1);
            AddWorker(workers, "Моставчук Петро", 2500, "Розробник", 3);
            AddWorker(workers, "Степаненко Оля", 2000, "Розробник", 2);
            AddWorker(workers, "Федорчук Олег", 11000, "Директор", 6);
            AddWorker(workers, "Іванов Антон", 5500, "Розробник", 8);
            AddWorker(workers, "Кравчук Михайло", 3000, "Бухгалтер", 5);
            AddWorker(workers, "Антонов Степан", 5800, "Розробник", 7);
            AddWorker(workers, "Кравченко Олена", 6000, "Розробник", 9);
            DisplayEveryone(workers,listBox1);    
        }
        private void AddWorker(List<Worker> workers, String name, int salary, String position, int exp)
        {
            workers.Add(new Worker(name, salary, position, exp));
        }
        private void DisplayEveryone(List<Worker> workers, ListBox listBox1)
        {
            foreach (Worker worker in workers)
            {
                listBox1.Items.Add(worker.name + "\t\t" + worker.salary + "\t\t" + worker.position + "\t\t" + worker.exp);
            }
        }
    }
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }
    }
}