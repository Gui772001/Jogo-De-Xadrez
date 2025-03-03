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
                try
                {
                    Console.Clear();
                    Tela.imprimirPartida(partida);

                    Console.Write("Origem : ");
                    Posicao origim = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeOrigeb(origim);
                    bool[,] posicoesPossives = partida.tab.peca(origim).movimentosPossisveil();

                    Console.Clear();
                    Tela.impirmirTabuleiro(partida.tab, posicoesPossives);


                    Console.Write("Destino :");
                    Console.WriteLine(origim);
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    Console.WriteLine(destino);
                    partida.validarPosicaoDeDestino(origim, destino);
                    partida.realizaJogada(origim, destino);
                }


                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Tela.imprimirPartida(partida);
        }
        catch (Exception e) 
        {
            Console.WriteLine("Erro inesperado: " + e.Message);
            Console.ReadLine();
        
        }
    }
}