namespace Extiontions
{
    public static class Extend
    {
        extension(int value)
        {
             bool IsEven(int number)
            {
                return number % 2 == 0;
            }
        }
        extension(string value)
        {
             bool IsValidEmail(string email)
            {
                return email.Contains('@');
            }
        }
    }
}
