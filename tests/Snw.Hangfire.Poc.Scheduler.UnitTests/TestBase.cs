using System;
using Moq;

namespace Snw.Hangfire.Poc.Scheduler.UnitTests
{
    public abstract class TestBase : IDisposable
    {
        protected MockRepository MockRepository { get; }

        protected TestBase()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
        }

        public void Dispose()
        {
            MockRepository.VerifyAll();
        }
    }
}