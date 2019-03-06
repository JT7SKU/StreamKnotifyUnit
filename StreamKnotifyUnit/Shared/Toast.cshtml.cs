using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamKnotifyUnit.Services;


namespace StreamKnotifyUnit.Shared
{
    public class ToastBase : ComponentBase, IDisposable
    {
        [Inject] ToastService ToastService { get; set; }

        protected string Heading { get; set; }
        protected string Message { get; set; }
        protected bool IsVisible { get; set; }
        protected string BackgroundCssClass { get; set; }
        protected string IconCssClass { get; set; }

        protected override void OnInit()
        {
            ToastService.OnShow += ShowToast;
            ToastService.OnHide += HideToast;
        }

        private void ShowToast(string message, ToastLevel level)
        {
            BuildToastSettings(level, message);
            IsVisible = true;
            StateHasChanged();
        }

        private void HideToast()
        {
            IsVisible = false;
            StateHasChanged();
        }

        private void BuildToastSettings(ToastLevel level, string message)
        {
            switch (level)
            {
                case ToastLevel.NewFollower:
                    BackgroundCssClass = "bg-info";
                    IconCssClass = "info";
                    Heading = "Info";
                    break;
                case ToastLevel.NewSubscriber:
                    BackgroundCssClass = "bg-success";
                    IconCssClass = "check";
                    Heading = "Success";
                    break;
                case ToastLevel.NewTip:
                    BackgroundCssClass = "bg-warning";
                    IconCssClass = "exclamation";
                    Heading = "Warning";
                    break;
                case ToastLevel.NewCheer:
                    BackgroundCssClass = "bg-danger";
                    IconCssClass = "times";
                    Heading = "Error";
                    break;
            }

            Message = message;
        }

        public void Dispose()
        {
            ToastService.OnShow -= ShowToast;
        }
    }
}
