using ECommerce.Domain.Core.SeedWork;

namespace ECommerce.DomainLayer.Aggregates.Shared
{
    public class Money : ValueObject
    {
        public decimal Amount { get; init; }

        public string Currency { get; init; }
        private Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public override string ToString() 
        {
            return $"{Amount} {Currency}";
        }
        public static Money Create(decimal amount, string curreny)
        {
            return new Money(amount, curreny);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency;
            yield return Amount;
        }
    }
}
