using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using StdUnit.One.Shared;

namespace TApp.ViewModels.Realtime
{
    public class UILogsViewModel : ReactiveObject, IDisposable
    {
        private IDisposable _cleanup;
        public UILogsViewModel()
        {
            this.CmdClearFilter = ReactiveCommand.Create(() =>
            {
                this.EventGroup = "";
            });

            var disposeCmdClearFilterException = this.CmdClearFilter.ThrownExceptions.Subscribe(x => {
            });


            this.CmdClear = ReactiveCommand.Create(() =>
            {
                this._source.Clear();
            });
            var disposeCmdClear = this.CmdClear.ThrownExceptions.Subscribe(x => {
            });


            var eventgroupFilter = this.WhenAnyValue(x => x.EventGroup)
                .Throttle(TimeSpan.FromMilliseconds(400))
                .DistinctUntilChanged()
                .Select(x => {
                    Func<LogMessage, bool> res = lm => {
                        if (string.IsNullOrEmpty(x))
                        {
                            return true;
                        }
                        return lm.EventGroup == x;
                    };
                    return res;
                });

            this.ChangeObs = this._source.Connect()
                .Filter(eventgroupFilter);

            var d = this.ChangeObs
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _logs)
                .DisposeMany()
                .Subscribe();

            this._cleanup = new CompositeDisposable(
                d,
                disposeCmdClearFilterException,
                disposeCmdClear
            );

        }

        private SourceList<LogMessage> _source = new SourceList<LogMessage>();

        [Reactive]
        public bool ScrollEnabled { get; set; } = true;


        #region
        private readonly ReadOnlyObservableCollection<LogMessage> _logs;
        public ReadOnlyObservableCollection<LogMessage> Logs => _logs;
        public IObservable<IChangeSet<LogMessage>> ChangeObs { get; }
        #endregion

        #region
        [Reactive]
        public string EventGroup { get; set; }
        #endregion

        public void OnNext(LogMessage msg)
        {
            while (this._source.Count > 1000)
            {
                this._source.RemoveAt(0);
            }
            this._source.Add(msg);
        }

        public ReactiveCommand<Unit, Unit> CmdClearFilter { get; }
        public ReactiveCommand<Unit, Unit> CmdClear { get; }

        public void Dispose()
        {
            this._cleanup.Dispose();
        }
    }
}
