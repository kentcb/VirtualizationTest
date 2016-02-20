using System;
using System.Collections.Generic;

namespace VirtualisationTest.VMs
{
    public class EventGroupViewModel : List<EventViewModel>
    {
        private readonly DateTime? date;
        private readonly string text;

        public EventGroupViewModel(string text)
        {
            this.text = text;
        }

        public EventGroupViewModel(DateTime date, IList<EventViewModel> events)
        {
            this.date = date;
            this.AddRange(events);
        }

        public DateTime? Date
        {
            get { return this.date; }
        }

        public string DateDisplay
        {
            get
            {
                if (!this.Date.HasValue)
                {
                    return this.text;
                }

                return this.Date.Value.ToString("dd/MM/yyyy");
            }
        }
    }
}