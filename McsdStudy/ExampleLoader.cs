using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace McsdStudy
{
    class ExampleLoader
    {
        public ExampleLoader() :
            this(Environment.CurrentDirectory)
        {
        }

        public ExampleLoader(string exploreFolder)
        {
            ExploreFolder = exploreFolder;
        }

        public ICollection<Type> GetExamples()
        {
            List<Type> collectedExamples = new List<Type>();

            foreach(var found in Directory.EnumerateFiles(ExploreFolder, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(found);
                    foreach(var type in assembly.GetTypes())
                    {
                        if (type.GetInterface("Interfaces.ILoadableExample") != null)
                        {
                            collectedExamples.Add(type);
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }

            return collectedExamples;
        }

        public string ExploreFolder
        {
            get;
            set;
        }
    }
}
