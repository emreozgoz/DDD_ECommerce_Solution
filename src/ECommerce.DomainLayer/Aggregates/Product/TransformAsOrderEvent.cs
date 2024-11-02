using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainLayer.Aggregates.Product
{
    public record TransformAsOrderEvent(Guid orderId, Guid productId) : INotification;
   
}
