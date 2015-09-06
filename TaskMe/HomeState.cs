using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMe
{
    class HomeState : IState
    {
        private TaskManager _tm;

        public HomeState(TaskManager tm)
        {
            _tm = tm;
        }

        public IState run()
        {
            Task[] tasks = _tm.getTasks();

            while (true)
            {

                for (int i = 0; i < tasks.Length; i++ )
                {
                    Console.WriteLine(tasks[i].infoDump());
                    if (i == tasks.Length - 1)
                        Console.WriteLine();
                }

            
                Console.WriteLine("Add, Delete, Complete, end");

                var line = Console.ReadLine();

                if (line.Equals("add", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new AddState(_tm);
                }
                else if (line.Equals("delete", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new DeleteState(_tm);
                }
                else if (line.Equals("complete", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new CompleteState(_tm);
                }
                else if (line.Equals("end", StringComparison.CurrentCultureIgnoreCase))
                {
                    return null;
                }
            }
        }
    }
}
