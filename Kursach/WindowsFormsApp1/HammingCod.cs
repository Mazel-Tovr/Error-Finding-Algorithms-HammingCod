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
    public partial class HammingCod : Form
    {
       

        public HammingCod()
        {
            InitializeComponent();
            
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                listBox1.Items.Clear();
                S1 = null; S2 = null; S3 = null; S4 = null; S5 = null; Stroka_for_Unit_Tests1 = null;
                S = textBox1.Text;
                Coding();
                button2.Visible = true;
            }
            else MessageBox.Show("Введите данные");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (Sk.Length == textBox2.Text.Length)
            {
                S = textBox2.Text;
                DeCoding();
                button2.Visible = false;
                Stroka_for_Unit_Tests1 = null;
            }
            else
            {
                MessageBox.Show("Количесто бит должно быть равным " + Sk.Length);
            }
           
        }

        //Поля
        #region
        public string S { get; set; }
        public string Sk { get; set; }
        private string S1 { get; set; }
        private string S2 { get; set; }
        private string S3 { get; set; }
        private string S4 { get; set; }
        private string S5 { get; set; }
        private int NumBit { get; set; }
        private int[] sBoss1 = new int[0];
        private int[] sBoss2 = new int[0];
        private int[] sBoss3 = new int[0];
        private int[] sBoss4 = new int[0];
        private int[] sBoss5 = new int[0];

        public string Stroka_for_Unit_Tests1 { get; set; }
        #endregion

        public virtual void Coding()
        {              
                  #region
                    string primer = "";

                    primer = S;
                    primer = primer.Insert(0, "X").Insert(1, "X");

                    Sk = S; // для вывода
                    S = S.Insert(0, "0").Insert(1, "0"); // вставка нулей в 0, 2^0
                    NumBit = 2; //отсчет начинается с двух, так как первый два бита мы уже добавили            

                    for (int i = 4, j = 3; i < S.Length; i = (int)Math.Pow(2, j), j++)
                    {
                        NumBit++;
                        S = S.Insert(i - 1, "0");
                        primer = primer.Insert(i - 1, "X");
                    }
                    listBox1.Items.Add("Кол-во контрольных бит:  "+ NumBit);
                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("До вычисления самих контрольных бит, мы присвоили им значение ноль : "+ S);
                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("Х - места куда мы подставляем проверочные биты :  "+ primer);
                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("         Матрица");

                    string[] tem = new string[NumBit];
                     int x = S.Length;

                    //Строим подобие матрицы,зависящее от количества контрольных бит
                    // Контрольные биты , которые контролирует другие биты помечаються 1 , которые не контролируються 0
                    // Первая строчка  отвечает за 1,3,5,7,9 и так далее бит тоесть через один
                    for (int i = 0; i < S.Length / 2; i++)
                        S1 += "0";
                    for (int i = 0; i < S.Length; i = i + 2)
                        S1 = S1.Insert(i, "1");
                    listBox1.Items.Add(S1);
                    //Если контрольных бит >= 1 то вторая строчка отвечает за 2,3 6,7 тоесть через за 2 через два начиная со 2рого бита
                    if (NumBit >= 1)
                    {
                        for (int i = 0; i < S.Length / 2; i++)
                            S2 += "0";
                        for (int i = 1; i < S.Length; i = i + 4)
                            S2 = S2.Insert(i, "11");
                        if (S2.Length > S1.Length)
                        {
                            S2 = S2.Remove(S2.Length - 1);
                        }
                        else if (S2.Length < S1.Length)
                        {
                            S2 += "0";
                        }
                        listBox1.Items.Add(S2);
                    }
                    //Если контрольных бит >= 3 то вторая строчка отвечает за 4.5.6.7 тоесть за 4 бита через 4 бита
                    if (NumBit >= 3) // это костыль костылей :)
                    {
                        S3 = S;
                        S3 = S3.Replace('1', '0');

                        for (int i = 3; i < S.Length; i = i + 8)
                        {
                            S3 = S3.Insert(i, "1111");
                        }
                        if (S3.Length > S2.Length)
                        {
                            int raznica = S3.Length - S2.Length;
                            S3 = S3.Remove(S3.Length - raznica);
                        }
                        listBox1.Items.Add(S3);
                    }
                    // За 8 бит , через 8 
                    if (NumBit >= 4) // это костыль костылей :)
                    {
                        S4 = S;
                        S4 = S4.Replace('1', '0');

                        for (int i = 7; i < S.Length; i = i + 16)
                        {
                            S4 = S4.Insert(i, "11111111");
                        }
                        if (S4.Length > S3.Length)
                        {
                            int raznica = S4.Length - S3.Length;
                            S4 = S4.Remove(S4.Length - raznica);
                        }
                        listBox1.Items.Add(S4);
                    }

                    if (NumBit >= 5) // это костыль костылей :)
                    {
                        S5 = S;
                        S5 = S5.Replace('1', '0');

                        for (int i = 15; i < S.Length; i = i + 32)
                        {
                            S5 = S5.Insert(i, "1111111111111111");
                        }
                        if (S5.Length > S4.Length)
                        {
                            int raznica = S5.Length - S4.Length;
                            S5 = S5.Remove(S5.Length - raznica);
                        }
                        listBox1.Items.Add(S5);
                    }

                    // ---------- Вычисление контрольных бит ----------
                    //берём каждый контрольный бит и смотрим сколько среди контролируемых им битов единиц,
                    //получаем некоторое целое число и, если оно чётное, то ставим ноль,
                    //в противном случае ставим единицу.

                    // заносим в масивы числа из строчек
                    int[] sBoss = S.Select(ch => int.Parse(ch.ToString())).ToArray(); //массив из целых чисел
                   

                    // заносим в масивы числа из строчек
                    if (NumBit > 0)
                    {
                        sBoss1 = S1.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }
                    if (NumBit >= 1)
                    {
                        sBoss2 = S2.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }
                    if (NumBit >= 3)
                    {
                        sBoss3 = S3.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }
                    if (NumBit >= 4)
                    {
                        sBoss4 = S4.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }
                    if (NumBit >= 5)
                    {
                        sBoss5 = S5.Select(ch => int.Parse(ch.ToString())).ToArray();
                    }

                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("       Контрольные биты");

                    // читать описание выше что тут происходит
                    int temp = 0;
                    for (int i = 0; i < S.Length; i++)
                        temp += sBoss[i] * sBoss1[i]; //массив с изначальными значениями и массив 1ой строчки в матрице
                    if (temp > 1)
                        tem[0] = Convert.ToString(temp % 2);
                    else
                        tem[0] = Convert.ToString(temp);
                    listBox1.Items.Add("r1 =  "+ tem[0]);// первый проверочный бит 
                                                           //дальше по анологии 
                    int temp2 = 0;
                    if (NumBit >= 1)
                    {
                        for (int i = 0; i < S.Length; i++)
                            temp2 += sBoss[i] * sBoss2[i];
                        if (temp2 > 1)
                            tem[1] = Convert.ToString(temp2 % 2);
                        else
                            tem[1] = Convert.ToString(temp2);
                        listBox1.Items.Add("r2 =  "+ tem[1]);
                    }

                    int temp3 = 0;
                    if (NumBit >= 3)
                    {
                        for (int i = 0; i < S.Length; i++)
                            temp3 += sBoss[i] * sBoss3[i];
                        if (temp3 > 1)
                            tem[2] = Convert.ToString(temp3 % 2);
                        else
                            tem[2] = Convert.ToString(temp3);
                        listBox1.Items.Add("r3 =  "+ tem[2]);
                    }

                    int temp4 = 0;
                    if (NumBit >= 4)
                    {
                        for (int i = 0; i < S.Length; i++)
                            temp4 += sBoss[i] * sBoss4[i];
                        if (temp4 > 1)
                            tem[3] = Convert.ToString(temp4 % 2);
                        else
                            tem[3] = Convert.ToString(temp4);
                        listBox1.Items.Add("r4 =  "+ tem[3]);
                    }

                    int temp5 = 0;
                    if (NumBit >= 5)
                    {
                        for (int i = 0; i < S.Length; i++)
                            temp5 += sBoss[i] * sBoss5[i];
                        if (temp5 > 1)
                            tem[4] = Convert.ToString(temp5 % 2);
                        else
                            tem[4] = Convert.ToString(temp5);
                        listBox1.Items.Add("r5 =  "+ tem[4]);
                    }

                    //подставляем получиные значения в контрольные биты 
                    for (int i = 1, j = 1, k = 0; i < Sk.Length; i = (int)Math.Pow(2, j), j++, k++)
                    {
                        Sk = Sk.Insert(i - 1, tem[k]);
                    }
                    listBox1.Items.Add("-----------------------------");
                    listBox1.Items.Add("Полученная последовательность вычисление контрольных бит");
                    listBox1.Items.Add(Sk);
                    #endregion                
        }

        public void  DeCoding()
        {
            //Вся вторая часть алгоритма заключается в том, что необходимо заново вычислить все контрольные биты
            //(так же как и в первой части) и сравнить их с контрольными битами, которые мы получили
            #region
            listBox2.Items.Add("Матрица");
            listBox2.Items.Add("-----------------------------");
            if (!(S1 == null)) listBox2.Items.Add(S1);
            if (!(S2 == null)) listBox2.Items.Add(S2);
            if (!(S3 == null)) listBox2.Items.Add(S3);
            if (!(S4 == null)) listBox2.Items.Add(S4);
            if (!(S5 == null)) listBox2.Items.Add(S5);

            string[] mass = new string[NumBit];

            string was = "";
            was = S;
            int[] sBossDecode = S.Select(ch => int.Parse(ch.ToString())).ToArray(); //массив из целых чисел
            listBox2.Items.Add("-----------------------------");
            listBox2.Items.Add("--Контрольные биты --");
            int temp = 0;
            for (int i = 0; i < S.Length; i++)
                temp += sBossDecode[i] * sBoss1[i];
            if (temp > 1)
                mass[0] = Convert.ToString(temp % 2);
            else
                mass[0] = Convert.ToString(temp);
            listBox2.Items.Add("r1 =  " + mass[0]);

            if (NumBit >= 1)
            {
                int temp2 = 0;
                for (int i = 0; i < S.Length; i++)
                    temp2 += sBossDecode[i] * sBoss2[i];
                if (temp2 > 1)
                    mass[1] = Convert.ToString(temp2 % 2);
                else
                    mass[1] = Convert.ToString(temp2);
                listBox2.Items.Add("r2 =  " + mass[1]);
            }

            if (NumBit >= 3)
            {
                int temp3 = 0;
                for (int i = 0; i < S.Length; i++)
                    temp3 += sBossDecode[i] * sBoss3[i];
                if (temp3 > 1)
                    mass[2] = Convert.ToString(temp3 % 2);
                else
                    mass[2] = Convert.ToString(temp3);
                listBox2.Items.Add("r3 =  " + mass[2]);
            }

            if (NumBit >= 4)
            {
                int temp4 = 0;
                for (int i = 0; i < S.Length; i++)
                    temp4 += sBossDecode[i] * sBoss4[i];
                if (temp4 > 1)
                    mass[3] = Convert.ToString(temp4 % 2);
                else
                    mass[3] = Convert.ToString(temp4);
                listBox2.Items.Add("r4 =  " + mass[3]);
            }

            if (NumBit >= 5)
            {
                int temp5 = 0;
                for (int i = 0; i < S.Length; i++)
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
            if (NumBit >= 1)
            {
                if (mass[1] != "0")
                    plus += 2;
            }
            if (NumBit >= 3)
            {
                if (mass[2] != "0")
                    plus += 4;
            }
            if (NumBit >= 4)
            {
                if (mass[3] != "0")
                    plus += 8;
            }
            if (NumBit >= 5)
            {
                if (mass[4] != "0")
                    plus += 16;
            }

            if (plus != 0)
            {
                if (S[plus - 1] == '1')
                {
                    S = S.Remove(plus - 1, 1).Insert(plus - 1, "0");
                }
                else
                {
                    S = S.Remove(plus - 1, 1).Insert(plus - 1, "1");
                }
                listBox2.Items.Add("---------------------------");
                listBox2.Items.Add(String.Format("Ошибка на {0} позиции", plus));
                listBox2.Items.Add("-----------------------------");
                listBox2.Items.Add("Было  " + was);
                listBox2.Items.Add("-----------------------------");
                listBox2.Items.Add("Стало " + S);
                Stroka_for_Unit_Tests1 = S;
            }
            else
            {
                Stroka_for_Unit_Tests1 = "При передаче данных либо не была совершена ошибка , либо было совершенно больше одной";
                listBox2.Items.Add("-----------------------------");
                listBox2.Items.Add(Stroka_for_Unit_Tests1);
            }
            
            #endregion
        }

        //New Form Open <3
        private void добавлениеБитаЧетностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCountBitControl F = new AddCountBitControl();
            F.Show();
            this.Hide();
        }

        private void контрольнаяСуммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlSum F = new ControlSum();
            F.Show();
            this.Hide();
        }
    }
}

