using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Core.SeedWork
{
    public abstract class AggregateRoot : Entity
    {
        public readonly IList<INotification> events = [];

        //@ işareti yaparak değişkeni event olarak tanımlıyoruz. 
        /// <summary>
        /// Event üzerinden haberleşmek için kullanılır.
        /// </summary>
        /// <param name="event"></param>
        public void AddEvent(INotification @event)
        {
            events.Add(@event);
        }

        /// <summary>
        /// Event geri alınmak istenirse remove edilir
        /// </summary>
        /// <param name="event"></param>
        public void RemoveEvet(INotification @event)
        {
            events.Remove(@event);
        }


        /// <summary>
        /// Eventleri temizler. 
        /// </summary>
        public void ClearEvent()
        {
            events.Clear();
        }
    }
}
