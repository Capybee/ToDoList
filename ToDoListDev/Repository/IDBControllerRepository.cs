using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ToDoListDev.Models.Task;

namespace ToDoListDev.Repository
{
    public interface IDBControllerRepository
    {
        List<Task> GetTasks();
        bool AddTask(Task NewTask);
        bool UpdateTask(Task NewTask);
        bool DeleteTask(int TaskId);
        bool CompletingTask(int TaskId);
    }
}
