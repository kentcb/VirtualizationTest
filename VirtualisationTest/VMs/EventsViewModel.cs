using System;
using AlphaChiTech.Virtualization;
using System.Linq;

namespace VirtualisationTest.VMs
{
    public class EventsViewModel : IPagedSourceProvider<EventViewModel>
    {
        private readonly VirtualizingObservableCollection<EventViewModel> events;

        public EventsViewModel()
        {
            this.events = new VirtualizingObservableCollection<EventViewModel>(
                this,
                pageSize: 10,
                maxPages: 10);
        }

        public VirtualizingObservableCollection<EventViewModel> Events
        {
            get { return this.events; }
        }

        public PagedSourceItemsPacket<EventViewModel> GetItemsAt(int pageoffset, int count, bool usePlaceholder)
        {
            return new PagedSourceItemsPacket<EventViewModel> {
                LoadedAt = DateTime.Now,
                Items = Enumerable
                    .Range(pageoffset, count)
                    .Select(i => new EventViewModel("EVENT #" + i))
                    .ToList()
            };
        }

        public int Count
        {
            get
            {
                return 10000;
            }
        }

        public int IndexOf(EventViewModel item)
        {
            return -1;
        }

        public void OnReset(int count)
        {
        }
    }
}