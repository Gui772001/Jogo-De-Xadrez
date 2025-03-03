
using Tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    class Tela
    {

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            impirmirTabuleiro(partida.tab);
            Console.WriteLine();
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine("Turno : " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada : " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("Xeque!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas : ");
            Console.Write("Brancas " );
            imprimirConjunto(partida.pecasCaputuradas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCaputuradas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();

        }
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void impirmirTabuleiro(tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Coluna; j++)
                {


                    imprimiraPeca(tab.peca(i, j));
                    Console.Write(" ");


                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("  A  B  C  D  E  F  G  H");

        }
        public static void impirmirTabuleiro(tabuleiro tab, bool[,] PossicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor FundoAlterado = ConsoleColor.DarkBlue;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Coluna; j++)
                {
                    if (PossicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                        Console.Write(" ");
                    }



                    imprimiraPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;


                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("  A  B  C  D  E  F  G  H");
            Console.BackgroundColor = fundoOriginal;

        }
        public static void imprimiraPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                {
                    if (peca.cor == Cor.Branca)
                    {
                        Console.Write(peca);

                    }

                    else
                    {
                        ConsoleColor aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(peca);
                        Console.ForegroundColor = aux;
                    }
                    Console.Write(" ");
                }
            }
        }
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s.Substring(1));
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
