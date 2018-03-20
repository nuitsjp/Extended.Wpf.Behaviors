using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extended.Wpf.Behaviors.Utility;

namespace Extended.Wpf.Behaviors.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyObjectExtractor.Extract().ToList().ForEach(System.Console.WriteLine);
            System.Console.ReadLine();
        }
    }
}
