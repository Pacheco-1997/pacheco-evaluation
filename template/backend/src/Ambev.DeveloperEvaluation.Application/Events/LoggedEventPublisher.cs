using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Events
{
    public class LoggedEventPublisher<TEvent> : IEventPublisher<TEvent>
    {
        private readonly IEventRepository<TEvent> _repo;
        private readonly ILogger<LoggedEventPublisher<TEvent>> _logger;

        public LoggedEventPublisher(
            IEventRepository<TEvent> repo,
            ILogger<LoggedEventPublisher<TEvent>> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task PublishAsync(TEvent @event)
        {
            // 1) Persiste no Mongo
            //await _repo.SaveAsync(@event);

            // 2) “Publica” em log
            _logger.LogInformation(
                "Evento {EventName} publicado: {@Event}",
                typeof(TEvent).Name,
                @event);
        }
    }
}
