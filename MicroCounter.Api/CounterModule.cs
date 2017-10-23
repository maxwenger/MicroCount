using System;
using Nancy;
using Sider;

namespace MicroCounter.Api 
{
    public class CounterModule : Nancy.NancyModule 
    {
        private readonly RedisClient redis = new RedisClient("micro-counter-count-store", 6379);
        private const string COUNT_KEY = "count";
        

        public CounterModule()
        {
            EnableCORS();
            
            Get("/api/", args => GetCount().ToString());
            Post("/api/", args => PostCount().ToString());
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
        
        private void EnableCORS() =>
            After.AddItemToEndOfPipeline((ctx) => ctx.Response
                .WithHeader("Access-Control-Allow-Origin", "*")
                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type"));
    }
}
