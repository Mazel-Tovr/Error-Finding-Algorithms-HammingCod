using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddCountBitControl : Form
    {
        public AddCountBitControl()
        {
            InitializeComponent();
        }

        private void кодХэммингаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HammingCod F = new HammingCod();
            F.Show();
            this.Close();
        }

        //проверка на ввод данных
            #region
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!(e.KeyChar == 48 || e.KeyChar == 49 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!(e.KeyChar == 48 || e.KeyChar == 49 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
           
        }
        #endregion


        AddControlBit AddControlBit = new AddControlBit();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            AddControlBit.stroka = textBox1.Text;
            listBox1.Items.Add("Полученный код с контрольным битом ");
            listBox1.Items.Add(AddControlBit.codding());
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            if (textBox1.Text.Length+1 == textBox2.Text.Length)
            {
                AddControlBit.stroka = textBox2.Text;
                textBox3.Text = AddControlBit.decoding();
            }
            else MessageBox.Show("Вы не можете принять инфорацию, которая меньше или больше отправленной ");
        }
    }
}
