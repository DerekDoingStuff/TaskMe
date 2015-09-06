using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMe
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].Equals("/h", StringComparison.CurrentCultureIgnoreCase) ||
                    args[0].Equals("-h", StringComparison.CurrentCultureIgnoreCase) ||
                    args[0].Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Console based task manager");
                    Console.WriteLine("Author: Derek Hearn - Created: Sept 6 2015");
                    return;
                }
            }

            var sm = new StateManager(new HomeState(new TaskManager(new FileStore())));

            sm.run();
        }
    }

}
