namespace UoW.DataTypes.Knight
{
    using System.Collections.Generic;

    public static class LongExtensions
    {
        public static long AsLong(this string instance)
        {
            var success = long.TryParse(instance, out long value);
            return success ? value : 0;
        }

        public static IEnumerable<long> AsLongEnumerable(this string instance, char delimiter = ',')
        {
            var delimited = string.Empty;
            var hashSet = new HashSet<long>();
            if (instance.StartsWith('(') && instance.EndsWith(')'))
                delimited = instance[1..^1];

            foreach (var uno in delimited.Split(new[] { delimiter }))
                if (!string.IsNullOrEmpty(uno))
                    hashSet.Add(uno.AsLong());
            return hashSet;
        }
    }
}
