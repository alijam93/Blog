سی شارپ زبان بسیار خوبی است و بسیار باحال میباشد 
 ```cs
namespace MyApplication
{
    [Obsolete("...")]
    class Program : IInterface
    {
        public static List JustDoIt(int count)
        {
            Console.WriteLine($"Hello {Name}!");
            return new List (new int[] { 1, 2, 3 })
        }
    }
}
```