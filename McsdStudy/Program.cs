using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsdStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Testing Testing");

            ExampleLoader loader = new ExampleLoader();

            foreach (var type in loader.GetExamples())
            {
                Interfaces.ILoadableExample example = Activator.CreateInstance(type) as Interfaces.ILoadableExample;
                if (example != null)
                {
                    example.Run(args);
                }
            }
        }
    }
}
