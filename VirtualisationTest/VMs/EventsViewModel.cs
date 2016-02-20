using System;
using AlphaChiTech.Virtualization;
using System.Linq;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace VirtualisationTest.VMs
{
    public class EventsProvider : IPagedSourceProviderAsync<EventGroupViewModel>
    {
        PagedSourceItemsPacket<EventGroupViewModel> IPagedSourceProvider<EventGroupViewModel>.GetItemsAt(int pageoffset, int count, bool usePlaceholder)
        {
            throw new NotImplementedException();
        }

        int IPagedSourceProvider<EventGroupViewModel>.IndexOf(EventGroupViewModel item)
        {
            throw new NotImplementedException();
        }

        int IPagedSourceProvider<EventGroupViewModel>.Count
        {
            get { throw new NotImplementedException(); }
        }

        void IBaseSourceProvider.OnReset(int count)
        {
            throw new NotImplementedException();
        }

        private static readonly Random random = new Random();
        public async Task<PagedSourceItemsPacket<EventGroupViewModel>> GetItemsAtAsync(int pageoffset, int count, bool usePlaceholder)
        {
            await Task.Delay(1000);

            return
                new PagedSourceItemsPacket<EventGroupViewModel> {
                    LoadedAt = DateTime.Now,
                    Items = Enumerable
                        .Range(pageoffset, count)
                        .Select(i =>
                            new EventGroupViewModel(
                                DateTime.Now.AddDays(i).Date,
                                Enumerable
                                    .Range(0, random.Next(1, 10))
                                    .Select(num => new EventViewModel("EVENT #" + num))
                                    .ToList()))
                        .ToList()};
        }

        public EventGroupViewModel GetPlaceHolder(int index, int page, int offset)
        {
            return new EventGroupViewModel("Loading " + page + "/" + offset);
        }

        public async Task<int> GetCountAsync()
        {
            await Task.Delay(1500);
            return 10000;
        }

        public Task<int> IndexOfAsync(EventGroupViewModel item)
        {
            return Task.FromResult(-1);
        }
    }
    
    public class EventsViewModel : ReactiveObject
    {
        private VirtualizingObservableCollection<EventGroupViewModel> events;

        public EventsViewModel()
        {
            this.Events = new VirtualizingObservableCollection<EventGroupViewModel>(
                new EventsProvider(),
                pageSize: 10,
                maxPages: 10);
        }

        public VirtualizingObservableCollection<EventGroupViewModel> Events
        {
            get { return this.events; }
            private set { this.RaiseAndSetIfChanged(ref this.events, value); }
        }
    }
}