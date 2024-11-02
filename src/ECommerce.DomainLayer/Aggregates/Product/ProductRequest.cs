using ECommerce.Domain.Core.SeedWork;
using ECommerce.DomainLayer.Aggregates.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainLayer.Aggregates.Product
{
    public class ProductRequest : AggregateRoot
    {
        public Guid OrderId { get; init; }

        public Money ProductCost { get; init; }
        public int Stock { get; set; }
        public ProductRequestStatus Status { get; private set; }

        public ProductRequest()
        {

        }
        public ProductRequest(Guid orderId, Money productCost)
        {
            OrderId = orderId;
            ProductCost = productCost;
            Status = ProductRequestStatus.Submitted;
        }

        public void onApprove()
        {
            Status = ProductRequestStatus.inStock;
            AddEvent(new TransformAsOrderEvent(orderId: OrderId, productId: Id));
        }

        public void onRejected()
        {
            Status = ProductRequestStatus.outOfStock;
        }
    }
}
