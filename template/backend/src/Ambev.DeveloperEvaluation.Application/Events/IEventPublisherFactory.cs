using Ambev.DeveloperEvaluation.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Events
{
    public interface IEventPublisherFactory
    {
        IEventPublisher<TEvent> GetPublisher<TEvent>();
    }
}
