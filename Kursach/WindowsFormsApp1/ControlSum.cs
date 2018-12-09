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
    public partial class ControlSum : Form
    {
        public ControlSum()
        {
            InitializeComponent();
        }
        //проверка на ввод
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

        My_Algoritm_Control_Sum My_Algoritm_Control_Sum = new My_Algoritm_Control_Sum();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                My_Algoritm_Control_Sum.Stroka_Bits = textBox1.Text;
                My_Algoritm_Control_Sum.Control_Sum_Codding();
                textBox3.Text = My_Algoritm_Control_Sum.Control_Sum1.ToString();
                button2.Visible = true;
                button1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == textBox2.Text.Length)
            {
                My_Algoritm_Control_Sum.Stroka_Bits = textBox2.Text;
                My_Algoritm_Control_Sum.Control_Sum_DeCoding();
                textBox4.Text = My_Algoritm_Control_Sum.Control_Sum2.ToString();
                textBox5.Text = My_Algoritm_Control_Sum.ErrorCheck;
                button2.Visible = false;
                My_Algoritm_Control_Sum.Control_Sum1 = 0;
                My_Algoritm_Control_Sum.Control_Sum2 = 0;
                button1.Visible = true;
            }
            else MessageBox.Show("Вы не можете принять инфорацию, которая меньше или больше отправленной ");
        }

        private void кодХэммингаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HammingCod F = new HammingCod();
            F.Show();
            this.Close();
        }

        private void добавлениеБитаЧетностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCountBitControl F = new AddCountBitControl();
            F.Show();
            this.Close();
        }
    }
}
