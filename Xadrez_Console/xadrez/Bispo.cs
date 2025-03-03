
using System.Reflection.Emit;
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
            bool[,] mat = new bool[tab.Linhas, tab.Coluna];
            Posicao pos = new Posicao(0, 0);
            //No
     
            pos.definirValores(posicao.Linha - 1, posicao.Coluna -1);
            while (tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);

            }
            //NE
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);

            }
            //SE
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);

            }
            //So
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);

            }
            return mat;


        }
        public override string ToString()
        {
            return "B";
        }
    }
}
