using Tabuleiro;
using xadrez;
using Xadrez_Console;

internal class Program
{
    private static void Main(string[] args)
    {

        try
        {
            tabuleiro p = new tabuleiro(8, 8);

            PosicaoXadrez pos = new PosicaoXadrez('h',3);

            Console.WriteLine(pos.toPosicao());


            p.colocarpeca(new Torre(p, Cor.Preta), new Posicao(0, 0));

            p.colocarpeca(new Torre(p, Cor.Preta), new Posicao(1, 5));

            p.colocarpeca(new Rei(p, Cor.Preta), new Posicao(2, 3));
            p.colocarpeca(new Rei(p, Cor.Preta), new Posicao(2, 5));


            Tela.impirmirTabuleiro(p);




            Console.WriteLine("Posicão " + p);
            Console.ReadLine();
        }catch (TabuleiroException e)
        {
            Console.WriteLine(e);
        }
    }
}