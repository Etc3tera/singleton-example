using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Test
{
    [TestClass]
    public class ThreadSafeTest
    {
        // No-thread safe singleton
        // This test usually fails in most time
        [TestMethod]
        public void non_thread_safe()
        {
            var tasks = new Task[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    var _ = LazySingleton.Instance;
                });
            }
            Task.WaitAll(tasks);
            Assert.AreEqual(1, LazySingleton.InitCounter);
        }

        [TestMethod]
        public void thread_safe()
        {
            var tasks = new Task[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    var _ = LazyThreadSafeSingleton.Instance;
                });
            }
            Task.WaitAll(tasks);
            Assert.AreEqual(1, LazyThreadSafeSingleton.InitCounter);
        }
    }
}
