using Microsoft.VisualBasic;
using static WinFormsApp2.Form1;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        List<Worker> workers = new List<Worker>();
        DataBase dataBase;
        public Form1()
        {
            InitializeComponent();
            dataBase = new DataBase(workers, listBox1);

        }
        
        public String TextListBox(int index)
        {
            return workers[listBox1.SelectedIndex].name + "\t\t"
                 + workers[listBox1.SelectedIndex].salary + "\t\t"
                 + workers[listBox1.SelectedIndex].position+"\t\t"
                 + workers[listBox1.SelectedIndex].exp;
        }
        //Додати працівника
        private void button1_Click(object sender, EventArgs e)
        {
            Worker newWorker = new Worker("Прізвище Ім'я", 0, "Розробник", 0);
            string input1 = Interaction.InputBox("Введіть зарплату:", "", newWorker.salary.ToString());
            string input2 = Interaction.InputBox("Введіть прізвище та ім'я:", "", newWorker.name.ToString());
            string input3 = Interaction.InputBox("Введіть посаду:", "", newWorker.position.ToString());
            string input4 = Interaction.InputBox("Введіть стаж:", "", newWorker.exp.ToString());
            newWorker.salary = Convert.ToInt32(input1);
            newWorker.name = input2;
            newWorker.position = input3;
            newWorker.exp = Convert.ToInt32(input4);
            workers.Add(newWorker);
            listBox1.Items.Add(newWorker.name + "\t\t" + newWorker.salary + "\t\t" + newWorker.position+ "\t\t" + newWorker.exp);
        }
        //Видалити працівника
        private void button2_Click(object sender, EventArgs e)
        {
            // Перевірка, чи обраний елемент в listBox1
            if (listBox1.SelectedIndex != -1)
            {
                // Видалення працівника зі списку за індексом
                workers.RemoveAt(listBox1.SelectedIndex);
                // Видалення обраного елемента з listBox1
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть працівника, якого потрібно видалити.");
            }

        }
        //Зміна зарплати
        private void button3_Click(object sender, EventArgs e)
        {
            // Перевірка, чи обраний елемент в listBox1
            if (listBox1.SelectedIndex != -1)
            {
                // Показати діалогове вікно для введення зарплати
                string input = Interaction.InputBox("Введіть нову зарплату:", "Зміна зарплати", workers[listBox1.SelectedIndex].salary.ToString());
                // Зміна зарплати обраного працівника
                workers[listBox1.SelectedIndex].salary = Convert.ToInt32(input);
                listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть працівника");
            }
        }
        //Змінти посаду
        private void button4_Click(object sender, EventArgs e)
        {
            // Перевірка, чи обраний елемент в listBox1
            if (listBox1.SelectedIndex != -1)
            {
                string input = Interaction.InputBox("Введіть нову посаду:", "Зміна посади", workers[listBox1.SelectedIndex].position);
                // Зміна посади обраного працівника
                workers[listBox1.SelectedIndex].position = input;
                listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть працівника");
            }
        }
        //Змінити ім'я
        private void button5_Click(object sender, EventArgs e)
        {
            // Перевірка, чи обраний елемент в listBox1
            if (listBox1.SelectedIndex != -1)
            {
                string input = Interaction.InputBox("Введіть прізвище та ім'я:", "Зміна прізвища та ім'я", workers[listBox1.SelectedIndex].name);
                // Зміна ім'я обраного працівника
                workers[listBox1.SelectedIndex].name = input;
                listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть працівника");
            }
        }
        //Вихід з меню
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
        //Стаж -1
        private void button7_Click(object sender, EventArgs e)
        {
            // Перевірка, чи обраний елемент в listBox1
            if (listBox1.SelectedIndex != -1)
            {
                if (workers[listBox1.SelectedIndex].exp > 0)
                {
                    workers[listBox1.SelectedIndex].exp--;
                    // Зміна зарплати обраного працівника
                    listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
                }
                else MessageBox.Show("Стаж не може бути меншим за 0 років");
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть працівника");
            }
        }
        //Стаж +1
        private void button8_Click(object sender, EventArgs e)
        {
            // Перевірка, чи обраний елемент в listBox1
            if (listBox1.SelectedIndex != -1)
            {
                workers[listBox1.SelectedIndex].exp++;
                // Зміна зарплати обраного працівника
                listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть працівника");
            }
        }
        //Сортування за Прізвищем
        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { workers = SortMethod.Name2(workers); }
            else { workers = SortMethod.Name1(workers); }
            Display.Refresh(workers, listBox1);
        }
        //Сортування за стажем
        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { workers = SortMethod.Exp2(workers); }
            else { workers = SortMethod.Exp1(workers); }
            Display.Refresh(workers, listBox1);
        }
        //Сортування за зарплатою
        private void button11_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { workers = SortMethod.Salary2(workers); }
            else { workers = SortMethod.Salary1(workers); }
            Display.Refresh(workers, listBox1);
        }  
    }
}