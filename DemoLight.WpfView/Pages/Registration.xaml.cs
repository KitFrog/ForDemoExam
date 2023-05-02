using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoLight.WpfView.Helpers;
using DemoLight.WpfView.ViewModels.Vms;

namespace DemoLight.WpfView.Pages
{
    public partial class Registration : Page
    {
        private readonly DemoLightWin win;
        private readonly DataViewModel model;

        public Registration()
        {
            InitializeComponent();
            DataContext = DemoLightWin.Data;
            this.win = win;
            if (DataContext is DataViewModel model) this.model = model;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) => model.Pass = PassBox.Password;

        private void ConfwordBox_ConfwordChanged(object sender, RoutedEventArgs e) => model.ConfPass = ConfPassBox.Password;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(NavigateTo.Login, this);
        }
    }
}
