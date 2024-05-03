
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Kurs_addon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        FileStream? file = null;
        string[] strings;
        int range = 0;
        string filename;

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text + " ��� ����������");
            }
            else
            {
                if (textBox1.Text.Length == 0)
                {
                    listBox1.Items.Add("������������ ���");
                }
                else
                {
                    file = File.Create(textBox1.Text + ".txt");
               
                 
                    filename = file.Name;
                    listBox1.Items.Add("���� " + file.Name + " ������");
                    file.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // �������� ��������� ����
            filename = openFileDialog1.FileName;
            listBox1.Items.Add("���� " + openFileDialog1.FileName + " ������");

            strings = File.ReadAllLines(filename);
            range = strings.Length;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text;
            for (int i = 0; i < range; i++)
            {
                if (temp == strings[i])
                {
                    using (StreamWriter writer = new StreamWriter(filename, true))
                    {

                        writer.WriteLine("\n");
                    }
                    listBox1.Items.Add(temp + " ��� ���� � �����");
                    return;
                }
            }
            using (StreamWriter writer = new StreamWriter(filename, true))
            {

                writer.WriteLine(temp);
            }

            listBox1.Items.Add(temp + " ��������� � �������");
            strings = File.ReadAllLines(filename);
            range = strings.Length;
        }
    }
}