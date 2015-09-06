using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskMe
{
    class AddState : IState
    {
        private TaskManager _tm;

        public AddState(TaskManager _tm)
        {
            // TODO: Complete member initialization
            this._tm = _tm;
        }

        public IState run()
        {
            Console.Write("\nName: ");
            var name = Console.ReadLine();

            Console.Write("Info: ");

            var info = Console.ReadLine();

            var createDate = DateTime.UtcNow;

            var task = new Task(name, info, createDate);

            _tm.addTask(task);

            return new HomeState(_tm);
        }
    }
}
