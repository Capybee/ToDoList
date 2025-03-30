using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private Task _SelectedTask;
        public Task SelectedTask
        {
            get { return _SelectedTask; }
            set { _SelectedTask = value; OnPropertyChanged(nameof(SelectedTask)); }
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

        private RelayCommand _SelectedTaskDoubleClick;
        public RelayCommand SelectedTaskDoubleClick
        {
            get
            {
                return _SelectedTaskDoubleClick ?? (_SelectedTaskDoubleClick = new RelayCommand(obj =>
                {
                    WindowChangeTask WindowChangeTaskInstance = new WindowChangeTask();
                    WindowChangeTaskVM WindowChangeTaskVMInstance = new WindowChangeTaskVM(_SelectedTask);
                    WindowChangeTaskInstance.DataContext = WindowChangeTaskVMInstance;

                    if(WindowChangeTaskInstance.ShowDialog() == true)
                    {
                        Tasks = Repository.GetTasks();
                    }
                }));
            }
        }

        private RelayCommand _BtnMinimizeClick;
        public RelayCommand BtnMinimizeClick
        {
            get
            {
                return _BtnMinimizeClick ?? (_BtnMinimizeClick = new RelayCommand(obj =>
                {
                    Window ThisWindow = obj as Window;

                    ThisWindow.WindowState = WindowState.Minimized;
                }));
            }
        }

        private RelayCommand _BtnMaximizeClick;
        public RelayCommand BtnMaximizeClick
        {
            get
            {
                return _BtnMaximizeClick ?? (_BtnMaximizeClick = new RelayCommand(obj =>
                {
                    Window ThisWindow = obj as Window;

                    ThisWindow.WindowState = (ThisWindow.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
                }));
            }
        }

        private RelayCommand _BtnCloseClick;
        public RelayCommand BtnCloseClick
        {
            get
            {
                return _BtnCloseClick ?? (_BtnCloseClick = new RelayCommand(obj =>
                {
                    Window ThisWindow = obj as Window;

                    ThisWindow.Close();
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
