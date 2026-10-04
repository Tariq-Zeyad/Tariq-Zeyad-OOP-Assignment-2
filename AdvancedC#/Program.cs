namespace AdvancedC_
{
    public class Program
    {
        static void Main(string[] args)
        {
            String name = "null";
            if (name.HasValue())
            {
                Console.WriteLine("The Name has value .");
            }
            else
            {
                Console.WriteLine("The Value invalid ");
            }
        }
    }
}
