using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;
using Xadrez_Console;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();

        }
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudarJogador();
        }
        public void executaMovimento(Posicao origen, Posicao destino)
        {
            Peca p = tab.retirarPeca(origen);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarpeca(p, destino);

        }
        private void colocarPecas()
        {


            tab.colocarpeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c',1).toPosicao());
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c',2).toPosicao());
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d',2).toPosicao());
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e',2).toPosicao());
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('f',1).toPosicao());
            tab.colocarpeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('h',1).toPosicao());


        }
        public void validarPosicaoDeOrigeb(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não exite peça na posicão de origem escolhida");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peca de origem escolhida não é sua ");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não a movimetos possiveis para a peça de origem escolhida");
            }

        }
        public void validarPosicaoDeDestino(Posicao origem,Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição negada");

            }

        }

        private void mudarJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;

            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
    }
}
