using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMe
{
    public class Task
    {
        public DateTime createDate { get; private set; }
        public DateTime? completedDate { get; private set; }
        public string name { get; private set; }
        public string info { get; private set; }
    
        internal string infoDump()
        {
            if(completedDate.HasValue)
                return string.Format("DONE\n  Name [{0}]\n  Info [{1}]\n  Create Date [{2}]\n  Completion Date[{3}]", 
                    name, info, createDate.ToLocalTime(), completedDate.Value.ToLocalTime());
            else
                return string.Format("N[{0}]\nI[{1}]\nC[{2}]", name, info, createDate.ToLocalTime());
        }

        public Task(string name, string info, DateTime createDate)
        {
            this.name = name;
            this.info = info;
            this.createDate = createDate;
            this.completedDate = null;
        }

        public Task(string name, string info, DateTime createDate, DateTime completedDate)
        {
            this.name = name;
            this.info = info;
            this.createDate = createDate;
            this.completedDate = completedDate;
        }

        internal void complete()
        {
            completedDate = DateTime.UtcNow;
        }
    }
}
