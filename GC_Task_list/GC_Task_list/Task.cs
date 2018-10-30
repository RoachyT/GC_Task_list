using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_Task_list
{
    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool Completion { get; set; }

        public Task(string name, string description, string dueDate, bool completion)
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
            Completion = completion;
        }

        public Task(string name, string description, string dueDate)
        {

        }

        public string PrintName()
        {
            return Name;
        }
        public string PrintDescp()
        {
            return Description;
        }
        public string PrintDueDate()
        {
            return DueDate;
        }
       
    }
}
