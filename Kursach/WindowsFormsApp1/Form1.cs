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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Codding();
        }

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

        private int Button_Presed { get; set; }
        
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            s1 = null; s2 = null; s3 = null; s4 = null; s5 = null;
            Button_Presed = 1;
            s = textBox1.Text;
            Codding();
            button2.Visible = true;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (sk.Length == textBox2.Text.Length)
            {
                s = textBox2.Text;
                Button_Presed = 2;
                Codding();
            }
            else
            {
                MessageBox.Show("Количесто бит должно быть равным " + sk.Length);
            }
           
        }

        private string s { get; set; }
        private string sk { get; set; }
        private string s1 { get; set; }
        private string s2 { get; set; }
        private string s3 { get; set; }
        private string s4 { get; set; }
        private string s5 { get; set; }
        private int numBit { get; set; }
        private int[] sBoss1 = new int[0];
        private int[] sBoss2 = new int[0];
        private int[] sBoss3 = new int[0];
        private int[] sBoss4 = new int[0];
        private int[] sBoss5 = new int[0];

        private void Codding()
        {
            switch (Button_Presed)
            {
                
                case 1:
                  #region
                    string primer = "";

                    primer = s;
                    primer = primer.Insert(0, "X").Insert(1, "X");

                    sk = s; // для вывода
                    s = s.Insert(0, "0").Insert(1, "0"); // вставка нулей в 0, 2^0
                    numBit = 2; //отсчет начинается с двух, так как первый два бита мы уже добавили            

                    for (int i = 4, j = 3; i < s.Length; i = (int)Math.Pow(2, j), j++)
                    {
                        numBit++;
                        s = s.Insert(i - 1, "0");
                        primer = primer.Insert(i - 1, "X");
                    }
                    listBox1.Items.Add("Кол-во контрольных бит:  "+ numBit);
                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("До вычисления самих контрольных бит, мы присвоили им значение ноль : "+ s);
                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("Х - места куда мы подставляем проверочные биты :  "+ primer);
                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("         Матрица");

                    string[] tem = new string[numBit];
                     int x = s.Length;

                    //Строим подобие матрицы,зависящее от количества контрольных бит
                    // Контрольные биты , которые контролирует другие биты помечаються 1 , которые не контролируються 0
                    // Первая строчка  отвечает за 1,3,5,7,9 и так далее бит тоесть через один
                    for (int i = 0; i < s.Length / 2; i++)
                        s1 += "0";
                    for (int i = 0; i < s.Length; i = i + 2)
                        s1 = s1.Insert(i, "1");
                    listBox1.Items.Add(s1);
                    //Если контрольных бит >= 1 то вторая строчка отвечает за 2,3 6,7 тоесть через за 2 через два начиная со 2рого бита
                    if (numBit >= 1)
                    {
                        for (int i = 0; i < s.Length / 2; i++)
                            s2 += "0";
                        for (int i = 1; i < s.Length; i = i + 4)
                            s2 = s2.Insert(i, "11");
                        if (s2.Length > s1.Length)
                        {
                            s2 = s2.Remove(s2.Length - 1);
                        }
                        else if (s2.Length < s1.Length)
                        {
                            s2 += "0";
                        }
                        listBox1.Items.Add(s2);
                    }
                    //Если контрольных бит >= 3 то вторая строчка отвечает за 4.5.6.7 тоесть за 4 бита через 4 бита
                    if (numBit >= 3) // это костыль костылей :)
                    {
                        s3 = s;
                        s3 = s3.Replace('1', '0');

                        for (int i = 3; i < s.Length; i = i + 8)
                        {
                            s3 = s3.Insert(i, "1111");
                        }
                        if (s3.Length > s2.Length)
                        {
                            int raznica = s3.Length - s2.Length;
                            s3 = s3.Remove(s3.Length - raznica);
                        }
                        listBox1.Items.Add(s3);
                    }
                    // За 8 бит , через 8 
                    if (numBit >= 4) // это костыль костылей :)
                    {
                        s4 = s;
                        s4 = s4.Replace('1', '0');

                        for (int i = 7; i < s.Length; i = i + 16)
                        {
                            s4 = s4.Insert(i, "11111111");
                        }
                        if (s4.Length > s3.Length)
                        {
                            int raznica = s4.Length - s3.Length;
                            s4 = s4.Remove(s4.Length - raznica);
                        }
                        listBox1.Items.Add(s4);
                    }

                    if (numBit >= 5) // это костыль костылей :)
                    {
                        s5 = s;
                        s5 = s5.Replace('1', '0');

                        for (int i = 15; i < s.Length; i = i + 32)
                        {
                            s5 = s5.Insert(i, "1111111111111111");
                        }
                        if (s5.Length > s4.Length)
                        {
                            int raznica = s5.Length - s4.Length;
                            s5 = s5.Remove(s5.Length - raznica);
                        }
                        listBox1.Items.Add(s5);
                    }

                    // ---------- Вычисление контрольных бит ----------
                    //берём каждый контрольный бит и смотрим сколько среди контролируемых им битов единиц,
                    //получаем некоторое целое число и, если оно чётное, то ставим ноль,
                    //в противном случае ставим единицу.

                    // заносим в масивы числа из строчек
                    int[] sBoss = s.Select(ch => int.Parse(ch.ToString())).ToArray(); //массив из целых чисел
                   

                    // заносим в масивы числа из строчек
                    if (numBit > 0)
                    {
                        sBoss1 = s1.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }
                    if (numBit >= 1)
                    {
                        sBoss2 = s2.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }
                    if (numBit >= 3)
                    {
                        sBoss3 = s3.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }
                    if (numBit >= 4)
                    {
                        sBoss4 = s4.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }
                    if (numBit >= 5)
                    {
                        sBoss5 = s5.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }

                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("       Контрольные биты");

                    // читать описание выше что тут происходит
                    int temp = 0;
                    for (int i = 0; i < s.Length; i++)
                        temp += sBoss[i] * sBoss1[i]; //массив с изначальными значениями и массив 1ой строчки в матрице
                    if (temp > 1)
                        tem[0] = Convert.ToString(temp % 2);
                    else
                        tem[0] = Convert.ToString(temp);
                    listBox1.Items.Add("r1 =  "+ tem[0]);// первый проверочный бит 
                                                           //дальше по анологии 
                    int temp2 = 0;
                    if (numBit >= 1)
                    {
                        for (int i = 0; i < s.Length; i++)
                            temp2 += sBoss[i] * sBoss2[i];
                        if (temp2 > 1)
                            tem[1] = Convert.ToString(temp2 % 2);
                        else
                            tem[1] = Convert.ToString(temp2);
                        listBox1.Items.Add("r2 =  "+ tem[1]);
                    }

                    int temp3 = 0;
                    if (numBit >= 3)
                    {
                        for (int i = 0; i < s.Length; i++)
                            temp3 += sBoss[i] * sBoss3[i];
                        if (temp3 > 1)
                            tem[2] = Convert.ToString(temp3 % 2);
                        else
                            tem[2] = Convert.ToString(temp3);
                        listBox1.Items.Add("r3 =  "+ tem[2]);
                    }

                    int temp4 = 0;
                    if (numBit >= 4)
                    {
                        for (int i = 0; i < s.Length; i++)
                            temp4 += sBoss[i] * sBoss4[i];
                        if (temp4 > 1)
                            tem[3] = Convert.ToString(temp4 % 2);
                        else
                            tem[3] = Convert.ToString(temp4);
                        listBox1.Items.Add("r4 =  "+ tem[3]);
                    }

                    int temp5 = 0;
                    if (numBit >= 5)
                    {
                        for (int i = 0; i < s.Length; i++)
                            temp5 += sBoss[i] * sBoss5[i];
                        if (temp5 > 1)
                            tem[4] = Convert.ToString(temp5 % 2);
                        else
                            tem[4] = Convert.ToString(temp5);
                        listBox1.Items.Add("r5 =  "+ tem[4]);
                    }

                    //подставляем получиные значения в контрольные биты 
                    for (int i = 1, j = 1, k = 0; i < sk.Length; i = (int)Math.Pow(2, j), j++, k++)
                    {
                        sk = sk.Insert(i - 1, tem[k]);
                    }
                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("Полученная последовательность вычисление контрольных бит");
                    listBox1.Items.Add(sk);
                    #endregion
                    break;
                    

                case 2:
                    //Вся вторая часть алгоритма заключается в том, что необходимо заново вычислить все контрольные биты
                    //(так же как и в первой части) и сравнить их с контрольными битами, которые мы получили
                    #region
                    listBox2.Items.Add("Матрица");
                    listBox2.Items.Add("-----------------------------");
                    if (!(s1 == null)) listBox2.Items.Add(s1);
                    if (!(s2 == null)) listBox2.Items.Add(s2);
                    if (!(s3 == null)) listBox2.Items.Add(s3);
                    if (!(s4 == null)) listBox2.Items.Add(s4);
                    if (!(s5 == null)) listBox2.Items.Add(s5);

                    string[] mass = new string[numBit];

                    string was = "";
                    was = s;
                    int[] sBossDecode = s.Select(ch => int.Parse(ch.ToString())).ToArray(); //массив из целых чисел
                    listBox2.Items.Add("-----------------------------");
                    listBox2.Items.Add("--Контрольные биты --");
                    temp = 0;
                    for (int i = 0; i < s.Length; i++)
                        temp += sBossDecode[i] * sBoss1[i];
                    if (temp > 1)
                        mass[0] = Convert.ToString(temp % 2);
                    else
                        mass[0] = Convert.ToString(temp);
                    listBox2.Items.Add("r1 =  "+ mass[0]);

                    if (numBit >= 1)
                    {
                        temp2 = 0;
                        for (int i = 0; i < s.Length; i++)
                            temp2 += sBossDecode[i] * sBoss2[i];
                        if (temp2 > 1)
                            mass[1] = Convert.ToString(temp2 % 2);
                        else
                            mass[1] = Convert.ToString(temp2);
                        listBox2.Items.Add("r2 =  "+ mass[1]);
                    }

                    if (numBit >= 3)
                    {
                        temp3 = 0;
                        for (int i = 0; i < s.Length; i++)
                            temp3 += sBossDecode[i] * sBoss3[i];
                        if (temp3 > 1)
                            mass[2] = Convert.ToString(temp3 % 2);
                        else
                            mass[2] = Convert.ToString(temp3);
                        listBox2.Items.Add("r3 =  "+ mass[2]);
                    }

                    if (numBit >= 4)
                    {
                        temp4 = 0;
                        for (int i = 0; i < s.Length; i++)
                            temp4 += sBossDecode[i] * sBoss4[i];
                        if (temp4 > 1)
                            mass[3] = Convert.ToString(temp4 % 2);
                        else
                            mass[3] = Convert.ToString(temp4);
                        listBox2.Items.Add("r4 =  "+ mass[3]);
                    }

                    if (numBit >= 5)
                    {
                        temp5 = 0;
                        for (int i = 0; i < s.Length; i++)
                            temp5 += sBossDecode[i] * sBoss5[i];
                        if (temp5 > 1)
                            mass[4] = Convert.ToString(temp5 % 2);
                        else
                            mass[4] = Convert.ToString(temp5);
                        listBox2.Items.Add("r5 =  " + mass[4]);
                    }

                    int plus = 0;

                    if (mass[0] != "0")
                        plus += 1;
                    if (numBit >= 1)
                    {
                        if (mass[1] != "0")
                            plus += 2;
                    }
                    if (numBit >= 3)
                    {
                        if (mass[2] != "0")
                            plus += 4;
                    }
                    if (numBit >= 4)
                    {
                        if (mass[3] != "0")
                            plus += 8;
                    }
                    if (numBit >= 5)
                    {
                        if (mass[4] != "0")
                            plus += 16;
                    }
                   
                    if (plus != 0)
                    {
                        if (s[plus - 1] == '1')
                        {
                            s = s.Remove(plus - 1, 1).Insert(plus - 1, "0");
                        }
                        else
                        {
                            s = s.Remove(plus - 1, 1).Insert(plus - 1, "1");
                        }
                        listBox2.Items.Add("---------------------------");
                        listBox2.Items.Add(String.Format("Ошибка на {0} позиции", plus));
                        listBox2.Items.Add("-----------------------------");
                        listBox2.Items.Add("Было  " + was);
                        listBox2.Items.Add("-----------------------------");
                        listBox2.Items.Add("Стало " + s);
                    }
                    else
                    {
                        listBox2.Items.Add("-----------------------------");
                        listBox2.Items.Add("При передаче данных либо не была совершена ошибка , либо было совершенно больше одной");
                    }
                    
                    #endregion
                    break;

            }

        }

    }
}

