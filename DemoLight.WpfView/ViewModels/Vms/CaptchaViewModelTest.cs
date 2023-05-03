using DemoLight.WpfView.Helpers;
using System;

namespace DemoLight.WpfView.ViewModels.Vms
{
    internal class CaptchaViewModelTest : CaptchaViewModel
    {
        public Action? LoginAction { private get; set; }
        public Action? RegisterAction { private get; set; }
        public CommonCommand GotoLogin { get; }
        public CommonCommand GotoRegister { get; } 

        public CaptchaViewModelTest()
        {
            GotoLogin = new CommonCommand(() =>
            {
                if (CaptchaOk)
                {
                    LoginAction?.Invoke();
                }
            });
            GotoRegister = new CommonCommand(() =>
            {
                RegisterAction?.Invoke();
            });
        }
    }
}

