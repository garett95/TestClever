using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCleverence
{
    class GetAddServer
    {
        private static int count;
        private static ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();
        public static int GetCount()
        {
            readerWriterLock.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }
        public static void AddToCount(int value)
        {
            readerWriterLock.EnterWriteLock();
            try
            {
                checked
                {
                    count += value;
                }
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }
    }
}
