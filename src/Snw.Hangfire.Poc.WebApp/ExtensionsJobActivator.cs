using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Snw.Hangfire.Poc.WebApp
{
    public class ExtensionsJobActivator : JobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        public ExtensionsJobActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override object ActivateJob(Type jobType)
        {
            return _serviceProvider.GetRequiredService(jobType);
        }

        public override JobActivatorScope BeginScope(JobActivatorContext context)
        {
            var scope = _serviceProvider.CreateScope();
            return new ExtensionsScope(_serviceProvider, scope);
        }
    }

    internal class ExtensionsScope : JobActivatorScope
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScope _scope;

        public ExtensionsScope(IServiceProvider serviceProvider, IServiceScope scope)
        {
            _serviceProvider = serviceProvider;
            _scope = scope;
        }

        public override object Resolve(Type type)
        {
            return _serviceProvider.GetRequiredService(type);
        }

        public override void DisposeScope()
        {
            _scope.Dispose();
        }
    }
}