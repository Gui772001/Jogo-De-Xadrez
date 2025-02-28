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
        public tabuleiro tab { get;  private set; }
        private int turno ;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new tabuleiro(8,8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();

        }

        public void executaMovimento(Posicao origen, Posicao destino)
        {
            Peca p = tab.retirarPeca(origen);
            p.incrementarQteMovimentos();
           Peca pecaCapturada=  tab.retirarPeca(destino);
            tab.colocarpeca(p, destino);

        }
        private void colocarPecas()
        {

          
            tab.colocarpeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarpeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('f', 1).toPosicao());
            tab.colocarpeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());


        }
    }
}
