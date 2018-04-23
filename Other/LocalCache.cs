using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class LocalCacheTest
    {
        public LocalCacheTest()
        {
            Console.WriteLine("******************** :" + DateTime.Now.Millisecond);
            for (int i = 0; i != 10;++i )
            {
                cacheObject co = new cacheObject(i);
                LocalMostFrequentUseCache.Instance.Cache(i, co);
            }
            Console.WriteLine("******************** :" + DateTime.Now.Millisecond);

            //for (int i = 0; i != 10000; ++i)
            //{
            //    cacheObject co =  LocalCache.Instance.Get<cacheObject>(i);
            //    Console.WriteLine(co.a);
            //}

            for (int i = 0; i != 10;++i )
            {
                cacheObject co = LocalMostFrequentUseCache.Instance.Get<cacheObject>(2);
                Console.WriteLine(co.a);
            }

            for (int i = 20; i != 30; ++i)
            {
                cacheObject co = new cacheObject(i);
                LocalMostFrequentUseCache.Instance.Cache(i, co);
            }

            //LocalMostFrequentUseCache.Instance.GetElapsedTimeSinceStartUp();

            Console.WriteLine("******************** :" + DateTime.Now.Millisecond);
        }

    }


    class cacheObject
    {
        public int a;
        public string b;

        public cacheObject(int i) {
            a = i;
            b = i.ToString();
        }
    }



    //1: 存储本地的东西。退出app的时候直接清空
    class LocalCache
    {
        private static readonly LocalCache instance = new LocalCache();
        public static LocalCache Instance { get { return instance; } }

        static LocalCache() { }

        private LocalCache() { }


        Hashtable hashTable = new Hashtable();
        public void Cache(object key,object value)
        {
            try
            {
                hashTable.Add(key, value);
            }
            catch(Exception e)
            {
                Console.WriteLine("LocalCache cache exception " + e);
            }
        }

        public T Get<T>(object key)
        {
            if(hashTable.ContainsKey(key))
            {
                T ret = default(T);
                try
                {
                    ret = (T)hashTable[key];
                } 
                catch(InvalidCastException e)
                {
                    Console.WriteLine("InvalidCastException " + e);
                }
                return ret;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public bool ContainsKey(object key)
        {
            return this.hashTable.ContainsKey(key);
        }

    }


    //MostFrequentUseCache  剔除最不经常使用的。  是依据使用次数还是最近一次的使用时间 （最近的使用时间）
    class LocalMostFrequentUseCache
    {
        private static readonly LocalMostFrequentUseCache instance = new LocalMostFrequentUseCache();
        public static LocalMostFrequentUseCache Instance { get { return instance; } }

        static LocalMostFrequentUseCache() { }

        private LocalMostFrequentUseCache() { }

        private const int MAXCOUNT = 15;

        Hashtable hashTable = new Hashtable();
        Dictionary<object, double> keyRefTimeDic = new Dictionary<object, double>();
        public void Cache(object key,object value)
        {
            try
            {
                if(hashTable.Count > MAXCOUNT)
                {
                    //使用时间最早的
                    object keykey = keyRefTimeDic.FirstOrDefault(x => x.Value == keyRefTimeDic.Values.Min()).Key;
                    hashTable.Remove(keykey);
                    keyRefTimeDic.Remove(keykey);
                }
                hashTable.Add(key, value);
                keyRefTimeDic.Add(key, GetElapsedTimeSinceStartUp());
            }
            catch(Exception e)
            {
                Console.WriteLine("LocalCache cache exception " + e);
            }
        }

        public T Get<T>(object key)
        {
            if(hashTable.ContainsKey(key))
            {
                T ret = default(T);
                try
                {
                    ret = (T)hashTable[key];
                    keyRefTimeDic[key] = GetElapsedTimeSinceStartUp();
                } 
                catch(InvalidCastException e)
                {
                    Console.WriteLine("InvalidCastException " + e);
                }
                return ret;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public bool ContainsKey(object key)
        {
            return this.hashTable.ContainsKey(key);
        }

        public double GetElapsedTimeSinceStartUp()
        {
             TimeSpan elapsedTime =  DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
             Console.WriteLine(elapsedTime.TotalSeconds);
             return elapsedTime.TotalSeconds;
        }
    }
}
