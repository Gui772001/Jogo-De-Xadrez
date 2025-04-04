﻿

namespace Tabuleiro
{
    class tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;


        public tabuleiro(int linhas, int coluna)
        {
            Linhas = linhas;
            Colunas = coluna;
            Pecas = new Peca[linhas, coluna];
        }

        public Peca peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
        public Peca peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }
        public void colocarpeca(Peca p, Posicao pos)
        {
            if (existePeca(pos)){
                throw new TabuleiroException("Já existe uma peça nessa posicão");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }
        public bool posicaoValida(Posicao pos)
        {
            if(pos.Linha < 0 || pos.Linha >=Linhas || pos.Coluna < 0  || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos)) { 
                throw new TabuleiroException("Posição invalida");
            }
        }
    }
}
