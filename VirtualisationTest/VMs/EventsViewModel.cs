using System;
using AlphaChiTech.Virtualization;
using System.Linq;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Threading.Tasks;

namespace VirtualisationTest.VMs
{
    public class EventsProvider : IPagedSourceProviderAsync<EventViewModel>
    {
        PagedSourceItemsPacket<EventViewModel> IPagedSourceProvider<EventViewModel>.GetItemsAt(int pageoffset, int count, bool usePlaceholder)
        {
            throw new NotImplementedException();
        }

        int IPagedSourceProvider<EventViewModel>.IndexOf(EventViewModel item)
        {
            throw new NotImplementedException();
        }

        int IPagedSourceProvider<EventViewModel>.Count
        {
            get { throw new NotImplementedException(); }
        }

        void IBaseSourceProvider.OnReset(int count)
        {
            throw new NotImplementedException();
        }

        public Task<PagedSourceItemsPacket<EventViewModel>> GetItemsAtAsync(int pageoffset, int count, bool usePlaceholder)
        {
            return Task.Delay(1000).ContinueWith(_ =>
                new PagedSourceItemsPacket<EventViewModel> {
                LoadedAt = DateTime.Now,
                Items = Enumerable
                    .Range(pageoffset, count)
                    .Select(i => new EventViewModel("EVENT #" + i))
                    .ToList()
                });
        }

        public EventViewModel GetPlaceHolder(int index, int page, int offset)
        {
            return EventViewModel.Placeholder;
        }

        public Task<int> GetCountAsync()
        {
            return Task.Delay(5000).ContinueWith(_ => 10000);
        }

        public Task<int> IndexOfAsync(EventViewModel item)
        {
            return Task.FromResult(-1);
        }
    }
    
    public class EventsViewModel : ReactiveObject
    {
        private VirtualizingObservableCollection<EventViewModel> events;

        public EventsViewModel()
        {
            RxApp
                .MainThreadScheduler
                    .Schedule(
                        (string)null,
                        TimeSpan.FromSeconds(10),
                        (scheduler, state) =>
                        {
                            this.Events = new VirtualizingObservableCollection<EventViewModel>(
                                new EventsProvider(),
                                pageSize: 10,
                                maxPages: 10);
                            return Disposable.Empty;
                        });
        }

        public VirtualizingObservableCollection<EventViewModel> Events
        {
            get { return this.events; }
            private set { this.RaiseAndSetIfChanged(ref this.events, value); }
        }
    }
}