using System;

using Xamarin.Forms;

namespace VirtualisationTest.VMs
{
    public class EventViewModel
    {
        public static readonly EventViewModel Placeholder = new EventViewModel("LOADING");

        private readonly string title;

        public EventViewModel(string title)
        {
            this.title = title;
        }

        public string Title
        {
            get { return this.title; }
        }
    }
}