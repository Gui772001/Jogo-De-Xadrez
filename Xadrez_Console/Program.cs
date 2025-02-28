using Tabuleiro;
using xadrez;
using Xadrez_Console;

internal class Program
{
    private static void Main(string[] args)
    {

        try
        {
            
            PartidaDeXadrez partida = new PartidaDeXadrez();
            while (!partida.terminada)
            {
                Console.Clear();
                Tela.impirmirTabuleiro(partida.tab);

                Console.WriteLine("Origem :");
                Posicao origim = Tela.lerPosicaoXadrez().toPosicao() ;
                Console.WriteLine("Destino");
                Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                partida.executaMovimento(origim, destino);
            }
           

        }catch (TabuleiroException e)
        {
            Console.WriteLine(e);
        }
    }
}