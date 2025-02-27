using Tabuleiro;

internal class Program
{
    private static void Main(string[] args)
    {
        tabuleiro p = new tabuleiro(3, 4);

        Console.WriteLine("Posicão " + p);
        Console.ReadLine();
    }
}