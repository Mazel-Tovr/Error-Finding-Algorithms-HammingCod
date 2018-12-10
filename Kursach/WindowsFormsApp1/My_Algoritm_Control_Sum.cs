using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class My_Algoritm_Control_Sum
    {

        public string Stroka_Bits { get; set; }

        public int Control_Sum1 { get;  set;}
        public int Control_Sum2 { get;  set; }
        public string ErrorCheck { get; private set; }

        public void Control_Sum_Codding()
        {
            if (Stroka_Bits != null)
            {
                int[] mass = Stroka_Bits.Select(ch => int.Parse(ch.ToString())).ToArray();// Add string to arry

                // Стоимость нахождения в массиве 
                int[] mass1 = new int[mass.Length];
                for (int i = 0, j = 2; i < mass1.Length; i++, j++)
                {
                    mass1[i] = j;
                }

                //Стоимость 1 или 0 в массиве, 0 - 1 ; 1 - 2
                int[] mass2 = new int[mass.Length];
                for (int i = 0; i < mass2.Length; i++)
                {
                    if (mass[i] == 0) mass2[i] = 1;

                    else mass2[i] = 2;
                }

                // теперь мы перемножаем массив1 и массив2 и заносим полученные значения в переменную
                for (int i = 0; i < mass1.Length; i++)
                {
                    Control_Sum1 += mass1[i] * mass2[i];
                }
                Stroka_Bits = null; //обнуляем строку 
            }

        }
        public void Control_Sum_DeCoding()
        {
            if (Stroka_Bits != null)
            {
                int[] mass = Stroka_Bits.Select(ch => int.Parse(ch.ToString())).ToArray();// Add string to arry

                // Стоимость нахождения в массиве 
                int[] mass1 = new int[mass.Length];
                for (int i = 0, j = 2; i < mass1.Length; i++, j++)
                {
                    mass1[i] = j;
                }

                //Стоимость 1 или 0 в массиве, 0 - 1 ; 1 - 2
                int[] mass2 = new int[mass.Length];
                for (int i = 0; i < mass2.Length; i++)
                {
                    if (mass[i] == 0) mass2[i] = 1;

                    else mass2[i] = 2;
                }

                // теперь мы перемножаем массив1 и массив2 и заносим полученные значения в переменную
                for (int i = 0; i < mass1.Length; i++)
                {
                    Control_Sum2 += mass1[i] * mass2[i];
                }


                // короче тут можно еше какой нибудь алгоритм запилить типо мы знаем контрольную сумму отправленных данных
                // и по ним можем узнать какие данные отправлены 
                // типо можно добавить словарь - например  010 = 12, 001 = 11 и так далее
                // и уже можно отпралять только контрольную сумму;

                Stroka_Bits = null; //обнуляем строку

                if (Control_Sum1 == Control_Sum2)
                {
                    ErrorCheck = "Ошибки не произошло, контрольные суммы равны ";
                }
                else ErrorCheck = "Произошла ошибка, контрольные суммы различны ";
            }
        }

    }
}
