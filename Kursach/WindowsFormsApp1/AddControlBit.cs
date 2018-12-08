using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AddControlBit
    {
        #region
        // Да какие ты тут коменты хотел увидеть все тоже самое что и в форме хэмминг код , но короче
        #endregion

        public string stroka { get; set; }
        // Добавляем контрольный бит четности
        public string coding( )
        {
            
            int[] mass = stroka.Select(ch => int.Parse(ch.ToString())).ToArray();
            int[] mass1 = new int[mass.Length];
            mass1 = mass;


            int count = 0;
            string result = "";
            for (int i = 0; i < mass.Length; i++)
                count += mass[i] * mass1[i];
            if (count > 1)
                result = Convert.ToString(count % 2);
            else
                result = Convert.ToString(count);

            stroka = stroka.Insert(stroka.Length, result);

            return stroka;
            
        }
        public string decoding()
        {

            int[] mass = stroka.Select(ch => int.Parse(ch.ToString())).ToArray();
            int a = Convert.ToInt16(mass[mass.Length - 1]);
            int[] mass1 = new int[mass.Length];
            mass1 = mass;

            int count = 0;
            int result;
            for (int i = 0; i < mass.Length - 1; i++)
                count += mass[i] * mass1[i];
            if (count > 1)
                result = count % 2;
            else
                result = count;

            
            if (result == a) return "При передаче данных либо ошибка не произошла, либо произошло две и больше ошибок";

            else return "При передаче данных произошла ошибка";

        }
        
    }
}
