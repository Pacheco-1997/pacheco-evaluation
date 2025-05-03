using Ambev.DeveloperEvaluation.Application.Events;
using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Events
{
    public class EventRepositoryFactory : IEventRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public EventRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEventRepository<TEvent> GetRepository<TEvent>()
            where TEvent : class
        {
            // Resolve do DI o IEventRepository<TEvent> registrado
            var repo = _serviceProvider.GetService<IEventRepository<TEvent>>();
            if (repo == null)
                throw new InvalidOperationException(
                    $"Nenhum IEventRepository<{typeof(TEvent).Name}> está registrado.");
            return repo;
        }
    }
}
