using System;
using Tarantool.Cache;

namespace TarantoolCacheExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cache = new TarantoolCache();

            cache.SetAsync(1, "test1").GetAwaiter().GetResult();

            var cacheValue = cache.Get(1).GetAwaiter().GetResult();

            Console.WriteLine($"Значение кэша: {cacheValue}");
        }
    }
}
