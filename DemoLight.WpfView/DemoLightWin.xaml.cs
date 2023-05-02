using System.Windows;
using DemoLight.WpfView.Helpers;
using DemoLight.WpfView.ViewModels.Vms;

namespace DemoLight.WpfView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DemoLightWin : Window
    {
        public DemoLightWin()
        {
            InitializeComponent();
            Navigation.Navigate(NavigateTo.Start, this);
        }

        private static DataViewModel data;
        public static DataViewModel Data
        {
            get
            {
                data = data ?? new DataViewModel();
                return data;
            }
        }
    }
}
