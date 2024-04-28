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
            AddWorker(workers, "�������� ����", 5000, "��������", 1);
            AddWorker(workers, "��������� �����", 2500, "���������", 3);
            AddWorker(workers, "���������� ���", 2000, "���������", 2);
            AddWorker(workers, "�������� ����", 11000, "��������", 6);
            AddWorker(workers, "������ �����", 5500, "���������", 8);
            AddWorker(workers, "������� �������", 3000, "���������", 5);
            AddWorker(workers, "������� ������", 5800, "���������", 7);
            AddWorker(workers, "��������� �����", 6000, "���������", 9);
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