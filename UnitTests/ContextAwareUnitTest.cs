using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    public class UnitTestWriteLine : Interfaces.IWriteLine
    {
        TestContext _context;

        public UnitTestWriteLine(TestContext context)
        {
            _context = context;
            Lines = new List<string>();
        }

        public void WriteLine(string line)
        {
            _context.WriteLine(line);
            (Lines as List<string>).Add(line);
        }

        public void WriteLine(string format, params object[] args)
        {
            _context.WriteLine(format, args);
            (Lines as List<string>).Add(String.Format(format, args));
        }

        public IList<string> Lines
        {
            get;
            private set;
        }
    }

    public class ContextAwareTest
    {
        public TestContext TestContext { get; set; }
    }
}
