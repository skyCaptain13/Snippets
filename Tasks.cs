using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static int Pig = 0;
        //=======================
        static Action<Action> measure = (body) =>
                   {
                       DateTime startTime = DateTime.Now;
                       if (Pig % 2 == 0)
                           Pig++;
                       else
                           Pig = Pig * 1;
                       body();
                       Console.WriteLine("{0} {1}", (DateTime.Now - startTime), Thread.CurrentThread.ManagedThreadId);
                   };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello there !");
            Action myCalc = () => { Thread.Sleep(1000); };

            measure(() =>
            {
                var Tsks = new[] 
                        {
                            Task.Factory.StartNew(()=> measure(myCalc)),
                            Task.Factory.StartNew(()=> measure(myCalc)),
                            Task.Factory.StartNew(()=> measure(myCalc)),
                            Task.Factory.StartNew(()=> measure(myCalc)),
                            Task.Factory.StartNew(()=> measure(myCalc)),
                            Task.Factory.StartNew(()=> measure(myCalc)),
                            Task.Factory.StartNew(()=> measure(myCalc)),
                            Task.Factory.StartNew(()=> measure(myCalc)),
                            Task.Factory.StartNew(()=> measure(myCalc))
                        };
                Task.WaitAll(Tsks);
            });


            Console.WriteLine("Pig is equal to: {0} ", Pig );
            Console.Read();
        }

    }
}