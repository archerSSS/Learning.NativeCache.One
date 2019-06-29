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


        [TestMethod]
        public void TestPutGetCount_7()
        {
            NativeCache<int> cache = new NativeCache<int>(4);
            
            cache.Put("3", 2);

            for (int i = 0; i < 4; i++)
                if (cache.values[i] != 0)
                {
                    Assert.AreEqual(2, cache.values[i]);
                    Assert.AreEqual("3", cache.slots[i]);
                }
        }


        [TestMethod]
        public void TestPutGetCount_8()
        {
            NativeCache<int> cache = new NativeCache<int>(4);

            cache.Put("2", 2);

            int[] v = cache.values;
            string[] s = cache.slots;
            int[] h = cache.hits;
            int index = 0;

            for (int i = 0; i < 4; i++)
                if (cache.values[i] != 0) index = i;

            Assert.AreEqual(2, cache.values[index]);
            Assert.AreEqual(true, cache.slots[index] != null);
            Assert.AreEqual(0, cache.hits[index]);
            Assert.AreEqual(2, cache.Get("2"));
            Assert.AreEqual(1, cache.hits[index]);
        }


        [TestMethod]
        public void TestPutGetCount_9()
        {
            NativeCache<int> cache = new NativeCache<int>(8);

            cache.Put("6", 3);

            int[] v = cache.values;
            string[] s = cache.slots;
            int[] h = cache.hits;
            int index = 0;

            for (int i = 0; i < 8; i++)
                if (cache.values[i] != 0) index = i;

            Assert.AreEqual(3, cache.values[index]);
            Assert.AreEqual(true, cache.slots[index] != null);
            Assert.AreEqual(0, cache.hits[index]);
            Assert.AreEqual(3, cache.Get("6"));
            Assert.AreEqual(1, cache.hits[index]);
        }


        [TestMethod]
        public void TestPutGetCount_10()
        {
            NativeCache<int> cache = new NativeCache<int>(6);

            cache.Put("1", 1);
            cache.Put("2", 1);
            cache.Put("3", 1);
            cache.Put("4", 1);
            cache.Put("5", 1);
            cache.Put("6", 1);


            // Выполнение запросов 1-6 раз (Значение с ключом "1" - 1 раз, значение с ключом "6" - 6 раз)
            // Пара значение-ключ "1" = 1 будут иметь меньшее число запросов и подлежит вытеснению.
            //
            cache.Get("1");
            cache.Get("2");
            cache.Get("2");
            cache.Get("3");
            cache.Get("3");
            cache.Get("3");
            cache.Get("4");
            cache.Get("4");
            cache.Get("4");
            cache.Get("4");
            cache.Get("5");
            cache.Get("5");
            cache.Get("5");
            cache.Get("5");
            cache.Get("5");
            cache.Get("6");
            cache.Get("6");
            cache.Get("6");
            cache.Get("6");
            cache.Get("6");
            cache.Get("6");


            // Добаление ключ-значение "11" - 2.
            // Происходит вытеснение менее востребованной пары "1" - 1.
            //
            //
            cache.Put("11", 2);
            Assert.AreEqual(0, cache.Get("1"));
            cache.Get("11");
            cache.Get("11");
            cache.Get("11");


            cache.Put("12", 2);
            Assert.AreEqual(0, cache.Get("2"));
            cache.Get("12");
            cache.Get("12");
            cache.Get("12");


            Assert.AreEqual(2, cache.Get("11"));
            Assert.AreEqual(2, cache.Get("12"));
            Assert.AreEqual(1, cache.Get("3"));
            Assert.AreEqual(1, cache.Get("4"));
            Assert.AreEqual(1, cache.Get("5"));
            Assert.AreEqual(1, cache.Get("6"));
        }
    }
}
