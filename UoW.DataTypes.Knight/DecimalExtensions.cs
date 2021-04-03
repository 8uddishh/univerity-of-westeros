namespace UoW.DataTypes.Knight
{
    using System.Collections.Generic;

    public static class DecimalExtensions
    {
        public static decimal AsDecimal(this string instance)
        {
            var success = decimal.TryParse(instance, out decimal value);
            return success ? value : 0;
        }

        public static IEnumerable<decimal> AsDecimalEnumerable(this string instance, char delimiter = ',')
        {
            var delimited = string.Empty;
            var hashSet = new HashSet<decimal>();
            if (instance.StartsWith('(') && instance.EndsWith(')'))
                delimited = instance[1..^1];

            foreach (var uno in delimited.Split(new[] { delimiter }))
                if (!string.IsNullOrEmpty(uno))
                    hashSet.Add(uno.AsDecimal());
            return hashSet;
        }
    }
}
