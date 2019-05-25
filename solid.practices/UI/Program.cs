using solid.practices.Infrastructure.Loggers;
using System;

namespace solid.practices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Rating System Starting...");

            var logger = new FileLogger();

            var engine = new RatingEngine(logger,
                                        new FilePolicySource(),
                                        new JsonPolicySerializer(),
                                        new RaterFactory(logger));
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

            Console.ReadKey();
        }
    }
}
