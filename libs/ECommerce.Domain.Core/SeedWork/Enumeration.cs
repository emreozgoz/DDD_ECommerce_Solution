using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Core.SeedWork
{
    public abstract class Enumeration : IComparable
    {
        public string Text { get; private set; }
        public int Value { get; private set; }
        protected Enumeration(string text, int value)
        {
            Text = text;
            Value = value;
        }
        public override string ToString() => Text;
        public static IEnumerable<TEnumeration> GetFields<TEnumeration>() where TEnumeration : Enumeration
        {
            var fields = typeof(TEnumeration).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<TEnumeration>();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);
            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static TEnumeration FromValue<TEnumeration>(int value) where TEnumeration : Enumeration
        {
            var matchingItem = Parse<TEnumeration, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }
      
        public static TEnumeration FromDisplayName<TEnumeration>(string displayName) where TEnumeration : Enumeration
        {
            var matchingItem = Parse<TEnumeration, string>(displayName, "display name", item => item.Text == displayName);
            return matchingItem;
        }
     
        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetFields<T>().FirstOrDefault(predicate);

            if (matchingItem is null)
                throw new FormatException($"'{value}' is not a valid {description} in {typeof(T)}");

            return matchingItem;
        }
        public int CompareTo(object? obj) => Value.CompareTo(((Enumeration)obj).Value);

    }
}
