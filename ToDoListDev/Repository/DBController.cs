using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ToDoListDev.Models.Task;

namespace ToDoListDev.Repository
{
    public class DBController
    {
        private static DbToDoListContext Context = new DbToDoListContext();

        public static List<Task> GetTasks()
        {
            List<Task> Tasks = Context.Tasks.ToList();

            foreach (var T in Tasks)
            {
                T.IsFinalBool = Convert.ToBoolean(T.IsFinal);
            }

            return Tasks;
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

        public static bool IsFinalChange(int Id, bool NewValue)
        {
            try
            {
                Context.Tasks.Find(Id).IsFinal = Convert.ToInt32(NewValue);
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
