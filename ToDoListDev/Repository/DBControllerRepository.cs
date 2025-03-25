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

        public bool UpdateTask(int Id, string NewTitle, string NewDescription, DateTime NewCompletionDate)
        {
            Tasks = DBController.GetTasks();
            foreach (Task T in Tasks)
            {
                if(T.Id == Id)
                {
                   return DBController.UpdateTask(Id, NewTitle, NewDescription, NewCompletionDate);
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool DeleteTasks(List<Task> DeletedTask)
        {
            return DBController.DeleteTasks(DeletedTask);
        }

        public bool IsFinalChange(int TaskId, bool NewValue)
        {
            return DBController.IsFinalChange(TaskId, NewValue);
        }
    }
}
