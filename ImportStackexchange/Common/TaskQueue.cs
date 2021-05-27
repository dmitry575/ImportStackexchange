using System;
using System.Threading;
using System.Threading.Tasks;

namespace ImportStackexchange.Common
{
    public class TaskQueue
    {
        private SemaphoreSlim semaphore;
        public TaskQueue(int maxThreads)
        {
            semaphore = new SemaphoreSlim(maxThreads);
        }

        public async Task<T> Enqueue<T>(Func<Task<T>> taskGenerator)
        {
            await semaphore.WaitAsync();
            try
            {
                return await taskGenerator();
            }
            finally
            {
                semaphore.Release();
            }
        }
        public async Task Enqueue(Func<Task> taskGenerator)
        {
            await semaphore.WaitAsync();
            try
            {
                await taskGenerator();
            }
            finally
            {
                semaphore.Release();
            }
        }

    }
}
