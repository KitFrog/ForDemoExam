using DemoLight.WpfView.ViewModels.Inerfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoLight.WpfView.ViewModels
{
    internal class CommandAsync : ICommandAsync
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Func<Task> execute;
        private readonly Func<bool>? canExecute;
        private bool isExecuting;
        private IErrorHundler errorHundler;

        public CommandAsync(Func<Task> execute, Func<bool>? canExecute, IErrorHundler errorHundler)
        {
            this.execute = execute;
            this.canExecute = canExecute;
            this.errorHundler = errorHundler;
        }

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute() => !isExecuting && (canExecute?.Invoke() ?? true);

        bool ICommand.CanExecute(object _) => CanExecute();

        void ICommand.Execute(object _) => FireAndForgetSafeAsync(ExecuteAsync(), errorHundler);

        public static async void FireAndForgetSafeAsync(Task task, IErrorHundler? errorHundler)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                errorHundler?.ErrorHundle(e);
            }
        }

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    isExecuting = true;
                    await execute.Invoke();
                }
                finally
                {
                    isExecuting = false;
                }
            }
        }
    }
}
