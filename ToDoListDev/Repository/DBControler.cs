using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ToDoListDev.Models.Task;

namespace ToDoListDev.Repository
{
    public class DBControler
    {
        private static DbToDoListContext Context = new DbToDoListContext();

        public static List<Task> GetTasks()
        {
            return Context.Tasks.ToList();
        }

        public static bool AddTask(Task NewTask)
        {
            try
            {
                Context.Tasks.Add(NewTask);
                Context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public static bool UpdateTask(Task ChangedTask)
        {
            try
            {
                Context.Tasks.Find(ChangedTask.Id).Title = ChangedTask.Title;
                Context.Tasks.Find(ChangedTask.Id).Description = ChangedTask.Description;
                Context.Tasks.Find(ChangedTask.Id).CreateDate = ChangedTask.CreateDate;
                Context.Tasks.Find(ChangedTask.Id).CompletionDate = ChangedTask.CompletionDate;
                Context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public static bool DeleteTask(Task DeletedTask)
        {
            try
            {
                Context.Tasks.Remove(DeletedTask);
                Context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public static bool CompletingTask(int Id)
        {
            try
            {
                Context.Tasks.Find(Id).IsFinal = 1;
                Context.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
    }
}
