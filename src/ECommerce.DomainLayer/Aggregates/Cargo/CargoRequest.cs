using ECommerce.Domain.Core.SeedWork;
using ECommerce.DomainLayer.Aggregates.Order;
using ECommerce.DomainLayer.Aggregates.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainLayer.Aggregates.Cargo
{
    public class CargoRequest : AggregateRoot
    {
        public Guid OrderId { get; init; }
        public Guid ProductId { get; init; }
        public CargoRequestStatus Status { get; private set; }

        public OrderRequest OrderRequest { get; private set; }
        public ProductRequest ProductRequest { get; private set; }
        public CargoRequest(Guid orderId, Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
            Status = CargoRequestStatus.Submitted;
        }
        public CargoRequest()
        {

        }

        public void onCancel()
        {
            Status = CargoRequestStatus.Canceled;
            AddEvent(new CargoCanceled(OrderId));
        }
    }
}
