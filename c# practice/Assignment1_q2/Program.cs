internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter list :");
        string? input = Console.ReadLine();
        string[]? number = input.Split(' ');

        bool isAscending = true;
        bool isDescending = true;
        int? prev = int.Parse(number[0]);

        for (int i = 1; i < number.Length; i++)
        {
            int? curr = int.Parse(number[i]);
            if (curr < prev)
            {
                isAscending = false;
            }
            else if (curr > prev)
            {
                isDescending = false;
            }
            prev = curr;
        }
        if (isAscending)
        {
            Console.WriteLine("The List is sorted");
        }
        else if (isDescending)
        {
            Console.WriteLine("The List is Sorted");
        }
        else
        {
            Console.WriteLine("The List is not sorted");
        }
        Console.ReadLine();
    }
}