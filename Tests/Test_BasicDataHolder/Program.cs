using KD.AutoBot;
using System;

namespace Test_BasicDataHolder
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataHolder dataHolder = new BasicDataHolder();
            dataHolder["valueTest"] = 10;

            Console.WriteLine(dataHolder["valueTest"]);

            Console.ReadKey();
        }
    }
}