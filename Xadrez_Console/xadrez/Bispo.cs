using Tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossisveil()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            int[] deslocamentosLinha = { -1, -1, 1, 1 };
            int[] deslocamentosColuna = { -1, 1, 1, -1 };

            for (int i = 0; i < 4; i++)
            {
                Posicao pos = new Posicao(posicao.Linha, posicao.Coluna);

                while (true)
                {
                    pos.definirValores(pos.Linha + deslocamentosLinha[i], pos.Coluna + deslocamentosColuna[i]);

                    if (!tab.posicaoValida(pos) || !podeMover(pos))
                        break;

                    mat[pos.Linha, pos.Coluna] = true;

                    if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                        break;
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}