using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McsdStudy
{
    public class AutoConsoleColor : IDisposable
    {
        ConsoleColor _original;

        public AutoConsoleColor(ConsoleColor c)
        {
            _original = Console.ForegroundColor;
            Console.ForegroundColor = c;
        }

        ~AutoConsoleColor()
        {
            OnDispose(false);
        }

        public void Dispose()
        {
            OnDispose(true);
            GC.SuppressFinalize(this);
        }

        private void OnDispose(bool disposing)
        {
            if (disposing)
            {
                Console.ForegroundColor = _original;
            }
        }
    }
}
