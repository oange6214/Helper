using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Common
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;


        public RelayCommand(Action execute)
        {
            _execute = execute;
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }


        #region -- ICommand Members --
        // 當 _canExecute 發生變更時，加入或是移除 Action 觸發事件
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }

        public void RaiseCanExecuteChange()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        // 下面兩個方法是提供給 View 使用的
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            // return _canExecute == null ? true : _canExecute();
            if (_canExecute == null) return true;
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
        #endregion
    }
}
