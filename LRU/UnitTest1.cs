using System;
using Xunit;
using System.Collections.Generic;
namespace LRU
{

    public interface ICommand
    {
        int Execute(LruCache lru);
    }

    public class Put : ICommand
    {
        int key;
        int value;

        public Put(int _key, int _value)
        {
            this.key = _key;
            this.value = _value;
        }

        public int Execute(LruCache lru)
        {
            lru.Put(this.key, this.value);
            return 0;
        }

    }

    public class Get : ICommand
    {
        int key;

        public Get(int _key)
        {
            key = _key;
        }

        public int Execute(LruCache lru)
        {
            return lru.Get(this.key);
        }

    }

    public class UnitTest1
    {

        public List<List<ICommand>> command;

        public UnitTest1()
        {

            command = new List<List<ICommand>>
            {
                new List<ICommand> {
                     new Put(1, 1),
                     new Put(2, 1),
                     new Get(2),
                     new Put(3, 2),
                     new Get(3)
                }
            };
    }

    [Theory]
    [InlineData(0,3,3)]
    public void Test1(int index, int capacity,int expectedResult)
    {
        LruCache lru = new LruCache(capacity);
        int result = 0;
        foreach (var item in command[index])
        {
           result = item.Execute(lru);
        }

        Assert.Equal(expectedResult,result);
    }
}
}
