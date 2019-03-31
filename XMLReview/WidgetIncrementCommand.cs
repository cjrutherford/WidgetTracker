using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XMLReview
{
    class WidgetIncrementCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _exec;

        public WidgetIncrementCommand(Action exe)
        {
            _exec = exe;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _exec.Invoke();
        }
    }
}
