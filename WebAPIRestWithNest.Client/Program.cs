using System;

namespace WebAPIRestWithNest.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultBatchWithJsonAndDefaultBatchHandler.DoRequest();
            Console.ReadLine();
        }
    }
}
