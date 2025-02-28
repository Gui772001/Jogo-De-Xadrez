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
                    Tela.impirmirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("Turno : " + partida.turno);
                    Console.WriteLine("Aguardando jogada : " + partida.jogadorAtual);

                    Console.Write("Origem : ");
                    Posicao origim = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeOrigeb(origim);
                    bool[,] posicoesPossives = partida.tab.peca(origim).movimentosPossisveil();

                    Console.Clear();
                    Tela.impirmirTabuleiro(partida.tab, posicoesPossives);


                    Console.Write("Destino :");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeDestino(origim, destino);
                    partida.realizaJogada(origim, destino);
                }


                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
        catch (Exception e) 
        {
            Console.WriteLine("Erro inesperado: " + e.Message);
            Console.ReadLine();
        }
    }
}