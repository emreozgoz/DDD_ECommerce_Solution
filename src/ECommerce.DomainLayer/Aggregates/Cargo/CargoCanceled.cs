using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainLayer.Aggregates.Cargo
{
    public record CargoCanceled(Guid orderId) : INotification;
}
