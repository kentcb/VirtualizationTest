using System;

using Xamarin.Forms;
using AlphaChiTech.Virtualization;
using VirtualisationTest.VMs;

namespace VirtualisationTest
{
    public class App : Application
    {
        public App()
        {
            if(!VirtualizationManager.IsInitialized)
            {
                VirtualizationManager.Instance.UIThreadExcecuteAction = (a) => Device.BeginInvokeOnMainThread(a);
                Device.StartTimer(
                    TimeSpan.FromSeconds(1),
                    () =>
                    {
                        VirtualizationManager.Instance.ProcessActions(); return true;
                    });
            }

            var vm = new EventsViewModel();

            MainPage = new EventsView {
                BindingContext = vm
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

