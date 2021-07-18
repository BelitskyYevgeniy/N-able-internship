using System.Threading;

namespace Synchronization
{
    public class Syncronizer
    {

        protected AutoResetEvent _writeLocker = new AutoResetEvent(true);
        protected ManualResetEvent _WriteEvent = new ManualResetEvent(true);
        protected ManualResetEvent _ReadEvent = new ManualResetEvent(true);

        public int WritersCount { get; private set; } = 0;
        public int ReadersCount { get; private set; } = 0;

        public void EnterWriter()
        {
            ++WritersCount;
            _ReadEvent.Reset();
            _WriteEvent.WaitOne();
            _writeLocker.WaitOne();
        }
        public void ReleaseWriter()
        {
            --WritersCount;
            if (WritersCount == 0)
            {
                _ReadEvent.Set();
            }
            _writeLocker.Set();
        }

        public void EnterReader()
        {

            _ReadEvent.WaitOne();
            ++ReadersCount;
            _WriteEvent.Reset();
        }
        public void ReleaseReader()
        {
            --ReadersCount;
            if (ReadersCount == 0)
            {
                _WriteEvent.Set();
            }
        }
            


    }
    
}
