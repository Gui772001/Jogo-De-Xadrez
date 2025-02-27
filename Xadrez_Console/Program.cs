using Tabuleiro;
using Xadrez_Console;

internal class Program
{
    private static void Main(string[] args)
    {
        tabuleiro p = new tabuleiro(8, 8);
        tabuleiro c = new tabuleiro(8, 8);


        Tela.impirmirTabuleiro(c);

        Console.WriteLine("Posicão " + p);
        Console.ReadLine();
    }
}