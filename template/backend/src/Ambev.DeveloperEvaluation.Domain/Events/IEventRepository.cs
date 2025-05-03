using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public interface IEventRepository<TEvent>
    {
        /// <summary>
        /// Persist the event.
        /// </summary>
        Task SaveAsync(TEvent @event);
    }
}
