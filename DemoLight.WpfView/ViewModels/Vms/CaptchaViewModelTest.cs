using System;

namespace DemoLight.WpfView.ViewModels.Vms
{
    internal class CaptchaViewModelTest : CaptchaViewModel
    {
        public Action? CalcAction { private get; set; }
        public CommonCommand GotoCalc { get; }

        public CaptchaViewModelTest()
        {
            GotoCalc = new CommonCommand(() =>
            {
                if (CaptchaOk)
                {
                    CalcAction?.Invoke();
                }
            });
        }
    }
}

