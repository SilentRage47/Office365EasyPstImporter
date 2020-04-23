using System;
using System.Windows.Input;

namespace Office365EasyImporter.ViewModels.Commands
{
    class RelayCommand : ICommand
    {
        Func<object, bool> canExecuteMethod;
        Action<object> executeMethod;
        public RelayCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteMethod != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
