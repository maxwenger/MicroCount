using System;
using Sider;

namespace MicroCounter.Api 
{
    public class CounterModule : Nancy.NancyModule 
    {
        private readonly RedisClient redis = new RedisClient("micro-counter-count-store", 6379);
        private const string COUNT_KEY = "count";
        

        public CounterModule()
        {
            Get("/", args => GetCount().ToString());
            Post("/", args => PostCount().ToString());
        }

        private int GetCount() 
        {
            var i = 0;
            
            var value = redis.Get(COUNT_KEY);
            Int32.TryParse(value, out i);
            
            return i;
        }

        private bool PostCount()
        {
            var value = GetCount();
            
            value++;
            redis.Set(COUNT_KEY, value.ToString());
            
            return true;
        }
    }
}
