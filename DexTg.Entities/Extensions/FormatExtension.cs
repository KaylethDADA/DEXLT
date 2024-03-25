namespace DexTg.Entities.Extensions
{
    public static class FormatExtension
    {
        public static string Format(this string text, object? obj)
        {
            if (obj == null)
                return text;

            if (obj is Array array && array.Length >= 2)
                return string.Format(text, array.Cast<object>().ToArray());

            return string.Format(text, obj);
        }
    }
}
