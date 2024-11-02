using ECommerce.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainLayer.Aggregates.Product
{
    public class ProductRequestStatus : Enumeration
    {

        public static ProductRequestStatus Submitted => new(100, "Submitted");
        public static ProductRequestStatus inStock => new(200, "In Stock");
        public static ProductRequestStatus outOfStock=> new(300, "Out Of Stock");
        public ProductRequestStatus(int value, string text) : base(value, text)
        {
        }
    }
}
