using Nancy;

namespace MicroCounter.Api 
{
    public class CounterModule : NancyModule 
    {
        public CounterModule()
        {
            Get("/", args => "This finally works, it only took *all night*. But what can you ask for, except to not wipe your hard drive -- or .Net to change config files -- or not to write RAW BIANARY DATA TO THE CSPROJ FILE. But you know, job security. Now to get redis online.");
        }
    }
}
