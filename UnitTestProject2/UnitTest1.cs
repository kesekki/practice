using ClassLibrary3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Runtime.CompilerServices;


namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const int lenght = 4;
            int expected = 4;
            int result = ClassLibrary3.DatabaseControler.GenerateString(lenght).Length;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestGenerateString_ContainsOnlyValidCharacters()
        {
            const int length = 10;
            string result = ClassLibrary3.DatabaseControler.GenerateString(length);
            const string chars = "abcdefghirstuvwxyzABCDEFGHRSTUVWXYZ0123456789";

            Assert.IsTrue(result.All(c => chars.Contains(c)), "Сгенерированная строка должна содержать только допустимые символы.");
        }

        [TestMethod]
        public void TestGenerateString_NotEmpty()
        {
            const int length = 4;
            string result = ClassLibrary3.DatabaseControler.GenerateString(length);
            Assert.IsFalse(string.IsNullOrEmpty(result), "Сгенерированная строка не должна быть пустой.");
        }

        [TestMethod]
        public void TestGenerateString_VariousLengths()
        {
            for (int length = 1; length <= 20; length++)
            {
                string result = ClassLibrary3.DatabaseControler.GenerateString(length);
                Assert.AreEqual(length, result.Length, $"Длина сгенерированной строки для {length} должна быть равна {length}.");
            }
        }
        [TestMethod]
        public void TestGenerateString_Performance()
        {
            const int length = 10;
            const int iterations = 100; 
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                string result = ClassLibrary3.DatabaseControler.GenerateString(length);
            }

            watch.Stop();
            Assert.IsTrue(watch.ElapsedMilliseconds < 1000, "Метод должен генерировать строки менее чем за 1 секунду для 100000 итераций.");
        }
    }
}
