using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace AlgoTest_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPutGetCount_1()
        {
            NativeCache<int> cache = new NativeCache<int>(16);
            for (int i = 0; i < cache.size; i++)
                cache.Put("" + i, 1);


            Assert.AreEqual(1, cache.Get("0"));
            Assert.AreEqual(1, cache.Get("1"));
            Assert.AreEqual(1, cache.Get("2"));
            Assert.AreEqual(1, cache.Get("3"));
            Assert.AreEqual(1, cache.Get("4"));
            Assert.AreEqual(1, cache.Get("5"));
            Assert.AreEqual(1, cache.Get("7"));
            Assert.AreEqual(1, cache.Get("8"));
            Assert.AreEqual(1, cache.Get("9"));
            Assert.AreEqual(1, cache.Get("10"));
            Assert.AreEqual(1, cache.Get("11"));
            Assert.AreEqual(1, cache.Get("12"));
            Assert.AreEqual(1, cache.Get("13"));
            Assert.AreEqual(1, cache.Get("14"));
            Assert.AreEqual(1, cache.Get("15"));
            
            cache.Put("new", 11);

            for (int i = 0; i < cache.size; i++)
            {
                if (i == 6) Assert.AreEqual(true, cache.Get("new") == 11);
                else Assert.AreEqual(true, cache.Get(""+i) == 1);
            }
        }


        [TestMethod]
        public void TestPutGetCount_2()
        {

            // Создание и заполнение кэша целочисленными значениями. 
            // 4 значения с ключами от 0 до 3 включительно. 
            // Все значения равные 1.
            // 
            NativeCache<int> cache = new NativeCache<int>(4);
            for (int i = 0; i < cache.size; i++)
                cache.Put("" + i, 1);


            // Проверка на наличие элементов спомощью метода Get(). 
            //  Таким образом активируя счетчик запросов.
            //
            Assert.AreEqual(true, cache.Get("2") == 1);
            Assert.AreEqual(true, cache.Get("0") == 1);
            Assert.AreEqual(true, cache.Get("1") == 1);

            
            // Замещение одного элемента другим(новые ключ и значение).
            //  Обнуление счетчика запроса по замещаемому ключу.
            //
            // Проверка на наличие ключей и их значений.
            //  Ключ "2" подвергается меньшему количеству запросов для его дальнейшего замещения.
            //
            //
            cache.Put("new", 11);
            Assert.AreEqual(true, cache.Get("2") == 1);
            Assert.AreEqual(true, cache.Get("0") == 1);
            Assert.AreEqual(true, cache.Get("1") == 1);
            Assert.AreEqual(true, cache.Get("1") == 1);
            Assert.AreEqual(true, cache.Get("0") == 1);
            Assert.AreEqual(true, cache.Get("new") == 11);
            Assert.AreEqual(true, cache.Get("new") == 11);
            Assert.AreEqual(true, cache.Get("new") == 11);

            cache.Put("new2", 12);

            Assert.AreEqual(true, cache.Get("new") == 11);
            Assert.AreEqual(true, cache.Get("new2") == 12);
            Assert.AreEqual(true, cache.Get("0") == 1);
            Assert.AreEqual(true, cache.Get("1") == 1);
        }



        [TestMethod]
        public void TestPutGetCount_3()
        {
            NativeCache<int> cache = new NativeCache<int>(4);
            for (int i = 0; i < cache.size; i++)
                cache.Put("" + i, 1);

            Assert.AreEqual(1, cache.Get("0"));
            Assert.AreEqual(1, cache.Get("1"));
            Assert.AreEqual(1, cache.Get("3"));

            cache.Put("new", 11);
            Assert.AreEqual(11, cache.Get("new"));
            Assert.AreEqual(1, cache.Get("0"));
            Assert.AreEqual(1, cache.Get("1"));
            Assert.AreEqual(1, cache.Get("3"));
            Assert.AreEqual(0, cache.Get("2"));
        }


        [TestMethod]
        public void TestPutGetCount_4()
        {
            NativeCache<int> cache = new NativeCache<int>(4);
            for (int i = 0; i < cache.size; i++)
                cache.Put("" + i, 1);

            for (int i = 0; i < 6; i++)
                cache.Get("0");

            for (int i = 0; i < 4; i++)
                cache.Get("1");

            for (int i = 0; i < 61; i++)
                cache.Get("2");

            for (int i = 0; i < 9; i++)
                cache.Get("3");

            cache.Put("1a", 2);

            Assert.AreEqual(0, cache.Get("1"));

            Assert.AreEqual(1, cache.Get("0"));
            Assert.AreEqual(2, cache.Get("1a"));
            Assert.AreEqual(1, cache.Get("2"));
            Assert.AreEqual(1, cache.Get("3"));
        }


        [TestMethod]
        public void TestPutGetCount_5()
        {
            NativeCache<int> cache = new NativeCache<int>(4);
            for (int i = 0; i < cache.size; i++)
                cache.Put("" + i, 1);

            for (int i = 0; i < 6; i++)
                cache.Get("0");

            for (int i = 0; i < 6; i++)
                cache.Get("1");

            for (int i = 0; i < 5; i++)
                cache.Get("2");

            for (int i = 0; i < 6; i++)
                cache.Get("3");

            cache.Put("2a", 2);

            Assert.AreEqual(0, cache.Get("2"));

            Assert.AreEqual(1, cache.Get("0"));
            Assert.AreEqual(1, cache.Get("1"));
            Assert.AreEqual(2, cache.Get("2a"));
            Assert.AreEqual(1, cache.Get("3"));
        }


        [TestMethod]
        public void TestPutGetCount_6()
        {
            NativeCache<int> cache = new NativeCache<int>(4);
            for (int i = 0; i < cache.size; i++)
                cache.Put("" + i, 0);

            for (int i = 0; i < 6; i++)
                cache.Get("0");

            for (int i = 0; i < 6; i++)
                cache.Get("1");

            for (int i = 0; i < 6; i++)
                cache.Get("2");

            for (int i = 0; i < 5; i++)
                cache.Get("3");

            cache.Put("3a", 2);

            Assert.AreEqual(0, cache.Get("3"));

            Assert.AreEqual(0, cache.Get("0"));
            Assert.AreEqual(0, cache.Get("1"));
            Assert.AreEqual(0, cache.Get("2"));
            Assert.AreEqual(2, cache.Get("3a"));
        }
    }
}
