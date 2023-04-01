using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLight.WpfView.ViewModels.Vms
{
    class CalcViewModel : ViewModelBase
    {
        private readonly Func<string, string, int> GetResult = CalcModel.Calc.Sum;
        private string x = string.Empty;
        public string X { get => x; set
            {
                if (SetField(ref x, value)) SetResult();
            } }
        private string y = string.Empty;
        public string Y
        {
            get => y; set
            {
                if (SetField(ref y, value)) SetResult();
            }
        }
        public int Result { get; private set; }

        private void SetResult()
        {
            Result = GetResult(x, y);
            OnPropertyChanged(nameof(Result));
        }
    }
}
