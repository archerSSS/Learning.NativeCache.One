using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures
{

    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        public int HashFun(string key)
        {
            if (key != null)
            {
                int nx = 0;
                char[] chs = key.ToCharArray();
                for (int i = 0; i < chs.Length; i++)
                    nx += Convert.ToInt32(chs[i]);
                return (55 * nx + 3) % 95 % size;
            }
            return 0;
        }

        public bool IsKey(string key)
        {
            int nx = FindSlot(key);
            if (nx != -1)
                return true;
            return false;
        }

        public void Put(string key, T value)
        {
            if (key != null)
            {
                int nx = HashFun(key);
                for (int i = 0; i < size; i++)
                {
                    if (slots[nx] == null || slots[nx] == key)
                    {
                        slots[nx] = key;
                        values[nx] = value;
                        break;
                    }
                    nx++;
                    if (nx >= size) nx = 0;
                }
                int erasedSlot = Array.IndexOf(hits, hits.Min());

                hits[erasedSlot] = 0;
                slots[erasedSlot] = key;
                values[erasedSlot] = value;
            }
        }

        public T Get(string key)
        {
            int nx = FindSlot(key);
            if (nx != -1)
            {
                hits[nx]++;
                return values[nx];
            }
            return default(T);
        }
        
        private int FindSlot(string key)
        {
            if (key != null)
            {
                int nx = HashFun(key);
                for (int i = 0; i < size; i++)
                {
                    if (slots[nx] == key)
                        return nx;
                    nx++;
                    if (nx >= size) nx = 0;
                }
            }
            return -1;
        } 
    }
}