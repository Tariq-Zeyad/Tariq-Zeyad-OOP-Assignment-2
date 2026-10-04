namespace AdvancedC_
{
    // 1- Mark class as static because it contains only static methods and cannot be instantiated.
    //This is a common practice for utility classes that provide extension methods.
    // 2- Mark Methods as static because extension methods must be static. They are called on instances of the extended type, but they are defined in a static class.
    // 3- This mark "HasVlue" extiontions method on "String"
    public static class StringExtentions
    {
        public static bool HasValue(this string value)
        {
            return !String.IsNullOrWhiteSpace(value);
        }
        public static string Truncate(this string value, int maxLength)
            => value.Length <= maxLength ? value : value[..maxLength];
    }
}
