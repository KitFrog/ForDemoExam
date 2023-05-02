using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using DataModels;
using DataModels.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using DemoLight.WpfView.ViewModels;
using DemoLight.WpfView.ViewModels.Inerfaces;

namespace ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        internal static readonly DataManager Data = DataManager.Get(DataProvider.SqLite);
        public static IErrorHundler? ErrorHundler { internal get; set; }
    }
}
