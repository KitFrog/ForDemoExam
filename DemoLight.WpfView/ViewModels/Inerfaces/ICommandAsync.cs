using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoLight.WpfView.ViewModels.Inerfaces
{
    internal interface ICommandAsync : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
