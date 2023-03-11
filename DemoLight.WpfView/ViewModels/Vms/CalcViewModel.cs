using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLight.WpfView.ViewModels.Vms
{
    class CalcViewModel : ViewModelBase
    {
        private readonly Func<int, int, int> GetResult = CalcModel.Calc.Sum;
        private int x;
        public int X { get => x; set
            {
                if (SetField(ref x, value)) SetResult();
            } }
        private int y;
        public int Y
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
