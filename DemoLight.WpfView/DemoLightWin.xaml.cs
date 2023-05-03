using System.Windows;
using DemoLight.WpfView.Helpers;
using DemoLight.WpfView.Pages;
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

        private static DataViewModel? data;
        public static DataViewModel Data
        {
            get
            {
                data = data ?? new DataViewModel();
                return data;
            }
        }

        private static Login login;
        public static Login Login(DemoLightWin main)
        {
            if (login == null)
            {
                login = new Login();
                Data.LoginOk = () =>
                {
                    Navigation.Navigate(NavigateTo.Calc, login);
                };
            }
            return login;
        }
    }
}
