using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DataModels;
using DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoLight.WpfView.ViewModels.Vms
{
    internal class DataViewModel : ViewModelBase
    {
        public Action? ReginOK { private get; set; }
        public Action? LoginOK { private get; set; }

        private readonly DataManager model = DataManager.Get(DataProvider.SqLite);
        private readonly ObservableCollection<User> users;
        public ObservableCollection<string> Names { get; }

        #region Commands
        public CommandAsync ReginAsync { get; }
        public CommandAsync RememberAsync { get; }
        public CommonCommand Login { get; }
        public CommonCommand ReginExit { get; }
        #endregion

        public static int SelectedId { get; set; }

        public DataViewModel()
        {
            users = new ObservableCollection<User>(model.UserRep.Users);
            Names = new ObservableCollection<string>(model
                .UserRep
                .Users
                .Include(u=>))
        }
    }
}
