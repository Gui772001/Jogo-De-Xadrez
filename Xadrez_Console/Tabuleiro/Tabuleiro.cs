

namespace Tabuleiro
{
    class tabuleiro
    {
        public int Linhas { get; set; }
        public int Coluna { get; set; }
        public Peca[,] Pecas;


        public tabuleiro(int linhas, int coluna)
        {
            Linhas = linhas;
            Coluna = coluna;
            Pecas = new Peca[linhas, coluna];
        }
    }
}
