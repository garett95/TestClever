using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCleverence
{
    class AsyncCaller
    {
        private EventHandler _handler;
        public AsyncCaller(EventHandler handler)
        {
            _handler = handler;
        }
        public bool Invoke(
            int ms,
            object sender,
            EventArgs e)
        {
            var task = Task.Factory.StartNew(() => _handler.Invoke(sender, e));

            return task.Wait(ms);
        }
    }
}
