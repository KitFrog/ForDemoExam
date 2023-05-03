using DataModels;
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
