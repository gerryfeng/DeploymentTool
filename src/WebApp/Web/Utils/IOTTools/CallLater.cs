using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Utils.IOTTools
{
    public class CallLater : IDisposable
    {
        private Timer _timer = null;
        private DateTime? _nextCall = null;

        public CallLater(TimerCallback callback, object state = null, int dueTime = 0)
        {
            if (dueTime != Timeout.Infinite)
            {
                _nextCall = DateTime.Now + TimeSpan.FromMilliseconds(dueTime);
            }
            else
            {
                _nextCall = null;
            }

            _timer = new Timer(o =>
            {
                _nextCall = null;

                if (!Monitor.TryEnter(this))
                {
                    Later(50);
                    return;
                }

                try
                {
                    callback.Invoke(o);
                }
                catch { }

                Monitor.Exit(this);

            }, state, dueTime, Timeout.Infinite);
        }
        public bool Later(int dueTime)
        {
            if (dueTime != Timeout.Infinite)
            {
                DateTime nextCall = DateTime.Now + TimeSpan.FromMilliseconds(dueTime);

                if (_nextCall != null && _nextCall.Value < nextCall)
                    return false;

                _nextCall = nextCall;
            }
            else
            {
                _nextCall = null;
            }

            return _timer.Change(dueTime, Timeout.Infinite);
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }

}
