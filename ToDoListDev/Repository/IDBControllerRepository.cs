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
        bool UpdateTask(int Id, string NewTitle, string NewDescription, DateTime NewCompletionDate);
        bool DeleteTask(Task DeletTask);
        bool IsFinalChange(int TaskId, bool NewValue);
    }
}
