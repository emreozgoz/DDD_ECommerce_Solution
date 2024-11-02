using ECommerce.Domain.Core.SeedWork;

namespace ECommerce.DomainLayer.Aggregates.Order
{
    public class OrderRequestStatus : Enumeration
    {
        public OrderRequestStatus(int value, string text) : base(value, text)
        {
        }

        public static OrderRequestStatus Submitted => new(100, "Submitted");
        public static OrderRequestStatus Completed => new(200, "Completed");
        public static OrderRequestStatus Canceled => new(300, "Canceled");
       
    }
}
