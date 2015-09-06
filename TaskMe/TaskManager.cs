using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskMe
{
    class TaskManager
    {
        ITaskData _dataStore;
        List<Task> tasks;

        public TaskManager(ITaskData dataStore)
        {
            _dataStore = dataStore;
        }

        internal Task[] getTasks()
        {
            if(tasks == null)
            {
                tasks = new List<Task>(_dataStore.loadTasks());
            }

            return tasks.ToArray();
        }

        internal void addTask(Task task)
        {
            if (tasks == null)
            {
                tasks = new List<Task>(_dataStore.loadTasks());
            }

            tasks.Add(task);

            _dataStore.saveTasks(tasks.ToArray());
        }

        internal void deleteTask(int index)
        {
            tasks.RemoveAt(index);
            _dataStore.saveTasks(tasks.ToArray());
        }

        internal void completeTask(int index)
        {
            tasks[index].complete();
            _dataStore.saveTasks(tasks.ToArray());
        }
    }
}
