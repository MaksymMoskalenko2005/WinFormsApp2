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
        //������ ����������
        private void button1_Click(object sender, EventArgs e)
        {
            Worker newWorker = new Worker("������� ��'�", 0, "���������", 0);
            string input1 = Interaction.InputBox("������ ��������:", "", newWorker.salary.ToString());
            string input2 = Interaction.InputBox("������ ������� �� ��'�:", "", newWorker.name.ToString());
            string input3 = Interaction.InputBox("������ ������:", "", newWorker.position.ToString());
            string input4 = Interaction.InputBox("������ ����:", "", newWorker.exp.ToString());
            newWorker.salary = Convert.ToInt32(input1);
            newWorker.name = input2;
            newWorker.position = input3;
            newWorker.exp = Convert.ToInt32(input4);
            workers.Add(newWorker);
            listBox1.Items.Add(newWorker.name + "\t\t" + newWorker.salary + "\t\t" + newWorker.position+ "\t\t" + newWorker.exp);
        }
        //�������� ����������
        private void button2_Click(object sender, EventArgs e)
        {
            // ��������, �� ������� ������� � listBox1
            if (listBox1.SelectedIndex != -1)
            {
                // ��������� ���������� � ������ �� ��������
                workers.RemoveAt(listBox1.SelectedIndex);
                // ��������� �������� �������� � listBox1
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("���� �����, ������� ����������, ����� ������� ��������.");
            }

        }
        //���� ��������
        private void button3_Click(object sender, EventArgs e)
        {
            // ��������, �� ������� ������� � listBox1
            if (listBox1.SelectedIndex != -1)
            {
                // �������� �������� ���� ��� �������� ��������
                string input = Interaction.InputBox("������ ���� ��������:", "���� ��������", workers[listBox1.SelectedIndex].salary.ToString());
                // ���� �������� �������� ����������
                workers[listBox1.SelectedIndex].salary = Convert.ToInt32(input);
                listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("���� �����, ������� ����������");
            }
        }
        //����� ������
        private void button4_Click(object sender, EventArgs e)
        {
            // ��������, �� ������� ������� � listBox1
            if (listBox1.SelectedIndex != -1)
            {
                string input = Interaction.InputBox("������ ���� ������:", "���� ������", workers[listBox1.SelectedIndex].position);
                // ���� ������ �������� ����������
                workers[listBox1.SelectedIndex].position = input;
                listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("���� �����, ������� ����������");
            }
        }
        //������ ��'�
        private void button5_Click(object sender, EventArgs e)
        {
            // ��������, �� ������� ������� � listBox1
            if (listBox1.SelectedIndex != -1)
            {
                string input = Interaction.InputBox("������ ������� �� ��'�:", "���� ������� �� ��'�", workers[listBox1.SelectedIndex].name);
                // ���� ��'� �������� ����������
                workers[listBox1.SelectedIndex].name = input;
                listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("���� �����, ������� ����������");
            }
        }
        //����� � ����
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
        //���� -1
        private void button7_Click(object sender, EventArgs e)
        {
            // ��������, �� ������� ������� � listBox1
            if (listBox1.SelectedIndex != -1)
            {
                if (workers[listBox1.SelectedIndex].exp > 0)
                {
                    workers[listBox1.SelectedIndex].exp--;
                    // ���� �������� �������� ����������
                    listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
                }
                else MessageBox.Show("���� �� ���� ���� ������ �� 0 ����");
            }
            else
            {
                MessageBox.Show("���� �����, ������� ����������");
            }
        }
        //���� +1
        private void button8_Click(object sender, EventArgs e)
        {
            // ��������, �� ������� ������� � listBox1
            if (listBox1.SelectedIndex != -1)
            {
                workers[listBox1.SelectedIndex].exp++;
                // ���� �������� �������� ����������
                listBox1.Items[listBox1.SelectedIndex] = TextListBox(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("���� �����, ������� ����������");
            }
        }
        //���������� �� ��������
        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { workers = SortMethod.Name2(workers); }
            else { workers = SortMethod.Name1(workers); }
            Display.Refresh(workers, listBox1);
        }
        //���������� �� ������
        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { workers = SortMethod.Exp2(workers); }
            else { workers = SortMethod.Exp1(workers); }
            Display.Refresh(workers, listBox1);
        }
        //���������� �� ���������
        private void button11_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { workers = SortMethod.Salary2(workers); }
            else { workers = SortMethod.Salary1(workers); }
            Display.Refresh(workers, listBox1);
        }  
    }
}