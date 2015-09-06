using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TaskMe
{
    class FileStore : ITaskData
    {
        private string _path = "tasks.txt";

        public Task[] loadTasks()
        {
            try
            {
                var lines = File.ReadAllLines(_path);

                var tasks = new List<Task>(lines.Length);

                for(int i = 0; i < lines.Length; i++)
                {
                    var split = lines[i].Split('|');
                    if(split.Length == 3)
                        tasks.Add(new Task(split[0], split[1], new DateTime(Int64.Parse(split[2]))));
                    else if (split.Length == 4)
                        tasks.Add(new Task(split[0], split[1], new DateTime(Int64.Parse(split[2])), new DateTime(Int64.Parse(split[3]))));
                }

                return tasks.ToArray();
            }
            catch (FileNotFoundException)
            {
                return new Task[0];
            }
        }

        public void saveTasks(Task[] tasks)
        {
            string[] taskLines = new string[tasks.Length];

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].completedDate.HasValue)
                    taskLines[i] = String.Format("{0}|{1}|{2}|{3}", tasks[i].name, tasks[i].info, tasks[i].createDate.Ticks, tasks[i].completedDate.Value.Ticks);
                else 
                    taskLines[i] = String.Format("{0}|{1}|{2}", tasks[i].name, tasks[i].info, tasks[i].createDate.Ticks);
            }

            File.WriteAllLines(_path, taskLines);
        }
    }
}
