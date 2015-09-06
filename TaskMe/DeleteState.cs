using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskMe
{
    class DeleteState : IState
    {
        private TaskManager _tm;

        public DeleteState(TaskManager _tm)
        {
            this._tm = _tm;
        }

        public IState run()
        {
            var tasks = _tm.getTasks();

            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine(String.Format("[{0}] {1}", i, tasks[i].infoDump()));
            }

            Console.Write("\nDelete Task Number: ");
            var line = Console.ReadLine();

            var index = Int32.Parse(line);

            _tm.deleteTask(index);

            return new HomeState(_tm);
        }
    }
}
