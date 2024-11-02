using ECommerce.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainLayer.Aggregates.Order
{
    public class PaymentRequestStatus : Enumeration
    {
        public PaymentRequestStatus(int value, string text) : base(value, text)
        {
        }
        public static PaymentRequestStatus Submitted => new(100, "Submitted");
        public static PaymentRequestStatus Completed => new(200, "Completed");
        public static PaymentRequestStatus Canceled => new(300, "Canceled");
    }
}
