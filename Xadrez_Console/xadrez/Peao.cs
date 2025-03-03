﻿using System.Dynamic;
using Tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
          
        }

        private bool existeInimico(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        public override bool[,] movimentosPossisveil()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Coluna];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValores(posicao.Linha - 1, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {

                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(posicao.Linha - 2, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos) && QteMovimentos == 0)
                {

                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && existeInimico(pos))
                {

                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (tab.posicaoValida(pos) && existeInimico(pos))
                {

                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.definirValores(posicao.Linha + 1, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {

                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(posicao.Linha + 2, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos) && QteMovimentos == 0)
                {

                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(posicao.Linha + 1, posicao.Coluna +1);
                if (tab.posicaoValida(pos) && existeInimico(pos))
                {

                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && existeInimico(pos))
                {

                    mat[pos.Linha, pos.Coluna] = true;
                }

            }


                return mat;
        }
    }
}