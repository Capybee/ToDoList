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
    public class WindowAddTaskVM : INotifyPropertyChanged
    {
        DBControllerRepository Repository = new DBControllerRepository();

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

        private DateTime _CompletionDate = DateTime.Now;
        public DateTime CompletionDate
        {
            get { return _CompletionDate; }
            set { _CompletionDate = value; OnPropertyChanged(nameof(CompletionDate)); }
        }

        private RelayCommand _BtnCancelClick;
        public RelayCommand BtnCancelClick
        {
            get
            {
                return _BtnCancelClick ?? (_BtnCancelClick = new RelayCommand(obj =>
                {
                    WindowAddTask WindowAddTaskInstance = obj as WindowAddTask;
                    WindowAddTaskInstance.DialogResult = true;
                }));
            }
        }

        private RelayCommand _BtnAddClick;
        public RelayCommand BtnAddClick
        {
            get
            {
                return _BtnAddClick ?? (_BtnAddClick = new RelayCommand(obj =>
                {
                    WindowAddTask WindowAddTaskInstance = obj as WindowAddTask;

                    if (!String.IsNullOrEmpty(Title))
                    {
                        Task NewTask = new Task(Title, (Description != null) ? Description : "" , DateTime.Now.ToString("dd.MM.yyyy"), (CompletionDate != null) ? CompletionDate.ToString("dd.MM.yyyy") : "");

                        WindowAddTaskInstance.DialogResult = Repository.AddTask(NewTask);
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
