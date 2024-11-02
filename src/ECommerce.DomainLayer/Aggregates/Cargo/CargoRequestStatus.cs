using ECommerce.Domain.Core.SeedWork;
using ECommerce.DomainLayer.Aggregates.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainLayer.Aggregates.Cargo
{
    public class CargoRequestStatus : Enumeration
    {

        public static CargoRequestStatus Submitted => new(100, "Submitted");
        public static CargoRequestStatus OnTheWay => new(200, "On The Way");
        public static CargoRequestStatus InDistribution => new(300, "In Distribution");
        public static CargoRequestStatus Delivered => new(400, "Delivered");
        public static CargoRequestStatus Canceled => new(400, "Canceled");
        public CargoRequestStatus(int value, string text) : base(value, text)
        {
        }
    }
}
