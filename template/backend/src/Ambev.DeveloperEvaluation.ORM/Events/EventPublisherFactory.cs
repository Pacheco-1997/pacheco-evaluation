using Ambev.DeveloperEvaluation.Application.Events;
using Ambev.DeveloperEvaluation.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Events
{
    public class EventPublisherFactory : IEventPublisherFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public EventPublisherFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEventPublisher<TEvent> GetPublisher<TEvent>()
        {
            var publisher = _serviceProvider.GetService(typeof(IEventPublisher<TEvent>))
                            as IEventPublisher<TEvent>;

            if (publisher == null)
                throw new InvalidOperationException($"No publisher registered for event type {typeof(TEvent).Name}");

            return publisher;
        }
    }
}
