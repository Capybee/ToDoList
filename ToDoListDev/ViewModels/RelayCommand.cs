using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoListDev.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> InputExecute, Func<object, bool> InputCanExecute = null)
        {
            _Execute = InputExecute;
            _CanExecute = InputCanExecute;
        }

        public bool CanExecute(object Parameter)
        {
            return _CanExecute == null || _CanExecute(Parameter);
        }

        public void Execute(object Parameter)
        {
            _Execute(Parameter);
        }
    }
}
