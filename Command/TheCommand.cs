using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoMvvm.Command
{
    class TheCommand : ICommand
    {
        //exeAction
        Action<object> _action;
        //can exe
        Func<object,bool> _func;
        bool _canExecute;
        public event EventHandler CanExecuteChanged;
        public TheCommand(Action<object> action, Func<object, bool> func = null, bool canExecute = false)
        {
          this._action = action;
            this._func = func;
            this._canExecute = canExecute;
        }
        

        // ask if can exeuction when the empty return true and if they not empty mean there is busy
        public bool CanExecute(object parameter)
        {
            if (_func == null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("_func(parameter)"+ _func(parameter));
                return !_func(parameter);
            }
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }


        public event EventHandler canExecutedChanged
        {
            add {
            CommandManager.RequerySuggested += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
