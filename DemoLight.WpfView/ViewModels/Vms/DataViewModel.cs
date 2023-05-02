using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataModels.Entities;
using DemoLight.WpfView.ViewModels.Inerfaces;
using Microsoft.EntityFrameworkCore;
using ViewModels;

namespace DemoLight.WpfView.ViewModels.Vms
{
    public class DataViewModel : ViewModelBase
    {
        public Action? ReginOK { private get; set; }
        public Action? LoginOK { private get; set; }

        private readonly DataManager model = MainViewModel.Data;
        private readonly ObservableCollection<User> users;
        public ObservableCollection<string>? Names { get; }

        #region Commands
        public CommandAsync ReginAsync { get; }
        public CommonCommand Login { get; }
        public CommonCommand ReginExit { get; }
        #endregion

        public DataViewModel()
        {
            users = new ObservableCollection<User>(model.UserRep.Users);

            Login = new CommonCommand(login, canExecuteLogin, MainViewModel.ErrorHundler);
            ReginAsync = new CommandAsync(reginAsync, canExecuteReginAsync, MainViewModel.ErrorHundler);
            ReginExit = new CommonCommand(() => ReginOK?.Invoke(), errorHundler: MainViewModel.ErrorHundler);
            SelectedName = User.Guest.FullName;

        }

        private bool canExecuteReginAsync()
        {
            if (pass == null || selectedName == null || pass != confPass || Pass?.Length < 2 || selectedName?.Length < 2) return false;
            return !users.Any(u => u.FullName.ToLower() == selectedName!.ToLower());
        }

        private async Task reginAsync()
        {
            int id=0;
            var user = new User()
            {
                Id = id,
                FullName = SelectedName,
                PasswordHash = DataModels.Helpers.GetHashString(pass!),
                Email = ""
            };

            await model.UserRep.UpdateAsync(user);
            Names.Add(SelectedName);
            Pass = "";
        }

        public static int SelectedId { get; set; }

        private string? pass;
        public string? Pass
        {
            get => pass;
            set
            {
                pass = value?.Trim();
                OnPropertyChanged("Pass");
                ReginAsync.RaiseCanExecuteChanged();
                Login.RaiseCanExecuteChanged();
            }
        }

        private string? confPass;

        public string? ConfPass
        {
            get => confPass;
            set
            {
                confPass = value?.Trim();
                OnPropertyChanged("ConfPass");
                ReginAsync.RaiseCanExecuteChanged();
            }
        }

        private string selectedName = "";
        public string SelectedName
        {
            get => selectedName;
            set
            {
                selectedName = value.Trim();
                OnPropertyChanged("SelectedName");
                ReginAsync.RaiseCanExecuteChanged();
                Login.RaiseCanExecuteChanged();
                var user = model.UserRep.Users.FirstOrDefault(u => u.FullName == selectedName);
            }
        }

        private void login()
        {
            LoginOK?.Invoke();
        }

        private bool canExecuteLogin()
        {
            if (selectedName == User.Guest.FullName)
            {
                SelectedId = User.Guest.Id;
                return true;
            }

            var user = model.UserRep.Users.FirstOrDefault(y => y.FullName == SelectedName);
            if (user != null) SelectedId = user.Id;
            return pass != null && user != null && user.PasswordHash == DataModels.Helpers.GetHashString(pass);
        }
    }
}
