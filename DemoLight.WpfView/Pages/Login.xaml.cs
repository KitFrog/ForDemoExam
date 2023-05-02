using DemoLight.WpfView.Helpers;
using DemoLight.WpfView.ViewModels.Vms;
using System.Windows;
using System.Windows.Controls;

namespace DemoLight.WpfView.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly DataViewModel model;
        public Login()
        {
            InitializeComponent();
            DataContext = DemoLightWin.Data;
            if (DataContext is DataViewModel model)
            {
                this.model = model;
                if (!string.IsNullOrEmpty(Name)) model.SelectedName = Name;

            }
        }

        bool noPass = true;
        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (noPass) model.Pass = PassBox.Password;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                noPass = false;
                Navigation.Navigate(NavigateTo.Registration, this);
            }
            finally
            {
                noPass = true;
            }
        }
    }
}
