
using System.Reflection.Emit;
using Tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(tabuleiro tab, Cor cor) : base(tab, cor) { 
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
            pos.definirValores(posicao.Linha - 1, posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos)){
                mat[pos.Linha, pos.Coluna] = true;

            }
            pos.definirValores(posicao.Linha - 1, posicao.Coluna +1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha, posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha +1 , posicao.Coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha + 1, posicao.Coluna -1 );
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;


        }
        public override string ToString()
        {
            return "R";
        }
    }
}
