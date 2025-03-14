using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoListDev.Repository;
using ToDoListDev.Views;
using Task = ToDoListDev.Models.Task;

namespace ToDoListDev.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private DBControllerRepository Repository = new DBControllerRepository();

        private List<Task> _Tasks = null!;
        public List<Task> Tasks
        {
            get { return _Tasks; }
            set { _Tasks = value; OnPropertyChanged(nameof(Tasks)); }
        }

        public MainWindowVM()
        {
            Tasks = Repository.GetTasks();
        }

        private RelayCommand _BtnAddTaskClick;
        public RelayCommand BtnAddTaskClick
        {
            get 
            {
                return _BtnAddTaskClick ?? (_BtnAddTaskClick = new RelayCommand(obj =>
                {
                    WindowAddTask WindowAddTaskInstance = new WindowAddTask();
                    WindowAddTaskVM WindowAddTaskVMInstance = new WindowAddTaskVM();
                    WindowAddTaskInstance.DataContext = WindowAddTaskVMInstance;

                    if(WindowAddTaskInstance.ShowDialog() == true)
                    {
                        Tasks = Repository.GetTasks();
                    }
                }));
            }
        }

        private RelayCommand _BtnDeleteTaskClick;
        public RelayCommand BtnDeleteTaskCLick
        {
            get
            {
                return _BtnDeleteTaskClick ?? (_BtnDeleteTaskClick = new RelayCommand(obj =>
                {
                    WindowDeleteTask WindowDeleteTaskInstance = new WindowDeleteTask();
                    WindowDeleteTaskVM WindowDeleteTaskVMInstance = new WindowDeleteTaskVM();
                    WindowDeleteTaskInstance.DataContext = WindowDeleteTaskVMInstance;

                    if(WindowDeleteTaskInstance.ShowDialog() == true)
                    {
                        Tasks = Repository.GetTasks();
                    }
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
