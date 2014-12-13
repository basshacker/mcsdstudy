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
            ExampleLoader loader = new ExampleLoader();

            Interfaces.IWriteLine writer = new ConsoleWriteLine();

            foreach (var type in loader.GetExamples())
            {
                Interfaces.ILoadableExample example = Activator.CreateInstance(type) as Interfaces.ILoadableExample;
                if (example != null)
                {
                    if (example.Initialize())
                    {
                        using(new AutoConsoleColor(ConsoleColor.Green))
                        {
                            writer.WriteLine("Example type {0} running.", example.GetType().Name);
                        }

                        try
                        {
                            example.Run(args, writer);
                        }
                        catch (Exception e)
                        {
                            using (new AutoConsoleColor(ConsoleColor.Red))
                            {
                                writer.WriteLine("Exception: {0}.", e.Message);
                                writer.WriteLine("Source: {0} ", e.Source);
                                writer.WriteLine("StackTrace: {0} ", e.StackTrace);
                            }
                            continue;
                        }
                        finally
                        {
                            using (new AutoConsoleColor(ConsoleColor.Green))
                            {
                                writer.WriteLine("Example type {0} done.", example.GetType().Name);
                            }
                        }
                    }
                    else
                    {
                        using (new AutoConsoleColor(ConsoleColor.Red))
                        {
                            writer.WriteLine("Example type {0} failed to Initialize. Skipping.", example.GetType().Name);
                        }
                    }

                    writer.WriteLine(String.Empty);
                }
            }
            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }
    }
}
