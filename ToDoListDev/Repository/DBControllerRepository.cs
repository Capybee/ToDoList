using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ToDoListDev.Models.Task;

namespace ToDoListDev.Repository
{
    public class DBControllerRepository : IDBControllerRepository
    {
        private List<Task> Tasks;

        public List<Task> GetTasks()
        {
            Tasks = DBController.GetTasks();
            return Tasks;
        }

        public bool AddTask(Task NewTask)
        {
            Tasks = DBController.GetTasks();
            if (Tasks != null)
            {
                foreach (Task T in Tasks)
                {
                    if (T == NewTask)
                    {
                        return false;
                    }
                }
            }

            return DBController.AddTask(NewTask);
        }

        public bool UpdateTask(Task NewTask)
        {
            Tasks = DBController.GetTasks();
            foreach (Task T in Tasks)
            {
                if(T.Id == NewTask.Id)
                {
                    if(T == NewTask)
                    {
                        if(T.CompletionDate == NewTask.CompletionDate)
                        {
                            return false;
                        }
                        return DBController.UpdateTask(NewTask);
                    }
                    else
                    {
                        return DBController.UpdateTask(NewTask);
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool DeleteTask(Task DeletedTask)
        {
            return DBController.DeleteTask(DeletedTask);
        }

        public bool IsFinalChange(int TaskId, bool NewValue)
        {
            return DBController.IsFinalChange(TaskId, NewValue);
        }
    }
}
