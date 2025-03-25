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
    public class WindowChangeTaskVM : INotifyPropertyChanged
    {
        DBControllerRepository Repository = new DBControllerRepository();
        int TaskId;

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; OnPropertyChanged(nameof(Title)); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; OnPropertyChanged(nameof(Description)); }
        }

        private DateTime _CompletionDate;
        public DateTime CompletionDate
        {
            get { return _CompletionDate; }
            set { _CompletionDate = value; OnPropertyChanged(nameof(CompletionDate)); }
        }

        public WindowChangeTaskVM() { }

        public WindowChangeTaskVM(Task InputTask)
        {
            Title = InputTask.Title;
            Description = InputTask.Description;
            CompletionDate = Convert.ToDateTime(InputTask.CompletionDate);
            TaskId = InputTask.Id;
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

        private RelayCommand _BtnSaveClick;
        public RelayCommand BtnSaveClick
        {
            get 
            {
                return _BtnSaveClick ?? (_BtnSaveClick = new RelayCommand(obj =>
                {
                    if(!string.IsNullOrWhiteSpace(Title))
                    {
                        Window ThisWindow = obj as Window;

                        ThisWindow.DialogResult = Repository.UpdateTask(TaskId, Title, Description, CompletionDate);
                    }
                    else
                    {
                        MessageBox.Show("Заголовок не может быть пустым!");
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
