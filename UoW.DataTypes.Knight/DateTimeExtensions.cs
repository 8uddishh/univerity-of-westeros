namespace UoW.DataTypes.Knight
{
    using System;
    using System.Collections.Generic;

    public static class DateTimeExtensions
    {
        public static DateTime AsDateTime(this string instance)
        {
            var success = DateTime.TryParse(instance, out DateTime value);
            return success ? value : new DateTime(2021, 01, 01);
        }

        public static IEnumerable<DateTime> AsDateTimeEnumerable(this string instance, char delimiter = ',')
        {
            var delimited = string.Empty;
            var hashSet = new HashSet<DateTime>();
            if (instance.StartsWith('(') && instance.EndsWith(')'))
                delimited = instance[1..^1];

            foreach (var uno in delimited.Split(new[] { delimiter }))
                if (!string.IsNullOrEmpty(uno))
                    hashSet.Add(uno.AsDateTime());
            return hashSet;
        }
    }
}
