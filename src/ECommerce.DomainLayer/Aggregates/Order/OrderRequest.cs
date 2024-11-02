using ECommerce.Domain.Core.SeedWork;
using ECommerce.DomainLayer.Aggregates.Shared;

namespace ECommerce.DomainLayer.Aggregates.Order
{
    public class OrderRequest : AggregateRoot
    {
        public OrderRequestStatus OrderStatus { get; private set; }
        public PaymentRequestStatus PaymentStatus { get; private set; }
        public string Description { get; set; }
        public string ShippingAddress { get; set; }
        public Money TotalAmount { get; init; }
        public OrderRequest()
        {

        }
        public OrderRequest(Money totalAmount, string description)
        {
            PaymentStatus = PaymentRequestStatus.Submitted;
            OrderStatus = OrderRequestStatus.Submitted; // Veritabanına ilk işaretlenecek State
            TotalAmount = totalAmount; // Bütçe
            ArgumentNullException.ThrowIfNull(description);
            Description = description;
        }


        public void OnCompleted()
        {
            if (OrderStatus.Equals(OrderRequestStatus.Submitted))
            {
                OrderStatus = OrderRequestStatus.Completed;
            }
            else if (OrderStatus.Equals(OrderRequestStatus.Canceled))
            {
                OrderStatus = OrderRequestStatus.Submitted;
                Console.Out.WriteLine("Canceled State olduğundan önce Submitted olarak işaretlenip sonra completed'a çevrildi");
                OnCompleted();
            }
        }

        public void OnCanceled()
        {
            if (OrderStatus.Equals(OrderRequestStatus.Submitted) || OrderStatus.Equals(OrderRequestStatus.Completed))
            {
                OrderStatus = OrderRequestStatus.Canceled;
            }
            else
            {
                throw new Exception("Zaten Request Iptal durumunda");
            }
        }
    }
}
