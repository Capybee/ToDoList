using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToDoListDev.Repository;
using Task = ToDoListDev.Models.Task;

namespace ToDoListDev.ViewModels
{
    public class WindowDeleteTaskVM : INotifyPropertyChanged
    {
        DBControllerRepository Repository = new DBControllerRepository();
        private List<Task> DeletedTasks = new List<Task>();

        private List<Task> _Tasks;
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


        public WindowDeleteTaskVM()
        {
            Tasks = Repository.GetTasks();
        }

        private RelayCommand _BtnCancelClick;
        public RelayCommand BtnCancelClick
        {
            get
            {
                return _BtnCancelClick ?? (_BtnCancelClick = new RelayCommand(obj =>
                {
                    Window ThisWindow = obj as Window;
                    ThisWindow.DialogResult = true;
                }));
            }
        }

        private RelayCommand _BtnDeleteClick;
        public RelayCommand BtnDeleteClick
        {
            get
            {
                return _BtnDeleteClick ?? (_BtnDeleteClick = new RelayCommand(obj =>
                {
                    Window ThisWindow = obj as Window;
                    var Result = MessageBox.Show("После удаления данные невозможно вернуть! Вы уверены, что хотите удалть?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (Result == MessageBoxResult.Yes)
                    {
                        Repository.DeleteTasks(DeletedTasks);
                    }

                    ThisWindow.DialogResult = true;
                }));
            }
        }

        private RelayCommand _MarkTask;
        public RelayCommand MarkTask
        {
            get
            {
                return _MarkTask ?? (_MarkTask = new RelayCommand(obj =>
                {
                    Button ThisButton = obj as Button;

                    if(!DeletedTasks.Contains(SelectedTask))
                    {
                        var BlackBrush = (SolidColorBrush)Application.Current.TryFindResource("MainBlackBrush");

                        ThisButton.Background = BlackBrush;

                        DeletedTasks.Add(SelectedTask);
                    }
                    else
                    {
                        var WhiteBrush = (SolidColorBrush) Application.Current.TryFindResource("MainWhite");
                        ThisButton.Background = WhiteBrush;
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
