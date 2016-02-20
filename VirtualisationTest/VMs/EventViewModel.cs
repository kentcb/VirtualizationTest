using System;

using Xamarin.Forms;

namespace VirtualisationTest.VMs
{
    public class EventViewModel
    {
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