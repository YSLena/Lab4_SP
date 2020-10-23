using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_sp
{
    public partial class Form1 : Form
    {
        DataAccess dataAcc = new DataAccess();

        public Form1()
        {
            InitializeComponent();

            dataAcc.form1 = this;
            //Test_dataGridView.DataSource = dataAcc.context.Test_Table.ToList();
        }

        private void func01button_Click(object sender, EventArgs e)
        {
            dataAcc.Task11(textBox11_1.Text, textBox11_2.Text);
        }

        private void func12button_Click(object sender, EventArgs e)
        {
            dataAcc.Task12(textBox12_1.Text, textBox12_2.Text);
        }

        private void func13button_Click(object sender, EventArgs e)
        {
            dataAcc.Task13(textBox13_1.Text, textBox13_2.Text);
        }

        private void func14button_Click(object sender, EventArgs e)
        {
            dataAcc.Task14(textBox14_1.Text, textBox14_2.Text);
        }

        private void func21button_Click(object sender, EventArgs e)
        {
            dataAcc.Task21(textBox21_1.Text, textBox21_2.Text, textBox21_3.Text);
            label_out21.Text = dataAcc.OutValue21.ToString();
        }

        private void func22button_Click(object sender, EventArgs e)
        {
            dataAcc.Task22(textBox22_1.Text, textBox22_2.Text);
            label_out22.Text = dataAcc.OutValue22.ToString();
        }

        private void func23button_Click(object sender, EventArgs e)
        {
            dataAcc.Task23(textBox23_1.Text, textBox23_2.Text);
        }
    }
}
