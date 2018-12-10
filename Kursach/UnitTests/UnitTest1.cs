using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void My_Algoritm_Control_Sum1()
        {
            var C = new My_Algoritm_Control_Sum();

            //Coding Test
            #region
            //данные для тестирования
            C.Stroka_Bits = "0101";
            int expected = 22;

            // Процесс работы 
            C.Control_Sum_Codding();
            var actual = C.Control_Sum1;
            //Проверка 
            Assert.AreEqual(expected, actual);
            #endregion


            //Decoding Test
            #region
            //данные для тестирования
            C.Stroka_Bits = "0101";
            int expected1 = 22;

            // Процесс работы 
            C.Control_Sum_DeCoding();
            var actual1 = C.Control_Sum2;
            //Проверка 
            Assert.AreEqual(expected1, actual1);
            #endregion

        }

        [TestMethod]
        public void My_Algoritm_Control_Sum2()
        {
            var C = new My_Algoritm_Control_Sum();

            //Coding Test
            #region
            //данные для тестирования
            C.Stroka_Bits = "10101";
            int expected = 32;

            // Процесс работы 
            C.Control_Sum_Codding();
            var actual = C.Control_Sum1;
            //Проверка 
            Assert.AreEqual(expected, actual);
            #endregion

            //Decoding Test
            #region
            //данные для тестирования
            C.Stroka_Bits = "10111";
            int expected1 = 37;

            // Процесс работы 
            C.Control_Sum_DeCoding();
            var actual1 = C.Control_Sum2;
            //Проверка 
            Assert.AreEqual(expected1, actual1);
            #endregion

            //Error Check
            #region
            string error = C.ErrorCheck.ToString();
            string expected_error = "Произошла ошибка, контрольные суммы различны ";
            Assert.AreEqual(expected_error, error);
            #endregion
        }

        [TestMethod]
        public void AddControlBit_Test1()
        {
            var C = new AddControlBit();
            //Coding Test
            #region
            C.Stroka = "00010";
            string exepted_stroka = "000101";
            string stroka = C.Add_Control_Bit_Coding();
            Assert.AreEqual(stroka, exepted_stroka);
            C.Stroka = null;
            #endregion

            //Decoding Test
            #region
            C.Stroka = "000101";
            string exepted = "При передаче данных либо ошибка не произошла, либо произошло две и больше ошибок";
            string stroka1 = C.Add_Control_Bit_Decoding();
            Assert.AreEqual(exepted, stroka1);
            #endregion

        }

        [TestMethod]
        public void AddControlBit_Test2()
        {
            var C = new AddControlBit();
            //Coding Test
            #region
            C.Stroka = "101010";
            string exepted_stroka = "1010101";
            string stroka = C.Add_Control_Bit_Coding();
            Assert.AreEqual(stroka, exepted_stroka);
            C.Stroka = null;
            #endregion

            //Decoding Test
            #region
            C.Stroka = "1010001";
            string exepted = "При передаче данных произошла ошибка";
            string stroka1 = C.Add_Control_Bit_Decoding();
            Assert.AreEqual(exepted, stroka1);
            #endregion
        }

        [TestMethod]
        public void HammingCodTest1()
        {
            var C = new HammingCod();

            //Coding Test
            #region
            C.S = "01001";
            C.Coding();
            string whatweget = C.Sk;
            string expected = "10011001";
            Assert.AreEqual(whatweget, expected);
            #endregion

            //Decoding Test
            #region
            C.S = "10011001";
            C.DeCoding();
            string whatweget1 = C.Stroka_for_Unit_Tests1;
            string expected1 = "При передаче данных либо не была совершена ошибка , либо было совершенно больше одной";
            Assert.AreEqual(whatweget1, expected1);
            #endregion
        }

        [TestMethod]
        public void HammingCodTest2()
        {
            var C = new HammingCod();

            //Coding Test
            #region
            C.S = "0101";
            C.Coding();
            string whatweget = C.Sk;
            string expected = "0100101";
            Assert.AreEqual(whatweget, expected);
            #endregion

            //Decoding Test
            #region
            C.S = "0100100";
            C.DeCoding();
            string whatweget1 = C.Stroka_for_Unit_Tests1;
            string expected1 = "0100101";
            Assert.AreEqual(whatweget1, expected1);
            #endregion
        }
    }
    
}
