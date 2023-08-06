internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();

        do
        {
            int num1 = random.Next(0, 11);
            int num2 = random.Next(0, 11);
            Console.WriteLine($"{num1}+{num2} = ");
            int answer = int.Parse(Console.ReadLine());
            int sum = num1 + num2;
            if (answer == sum)
            {
                Console.WriteLine("Your answer is correct.");

            }
            else
            {
                Console.WriteLine($"Your answer is incorrect. The correct answer is {sum}.");
            }
            Console.WriteLine("Do you want to try again (Y/N):");
            char choice = char.ToUpper(Console.ReadKey().KeyChar);
            if (choice != 'Y')
            {
                break;
            }
            Console.WriteLine();
        } while (true);
        Console.ReadLine(); 
    }
}