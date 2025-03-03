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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }


        public PartidaDeXadrez()
        {
            tab = new tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
           
        }
        public void realizaJogada(Posicao origem, Posicao destino)
        {

           Peca pecaCapturada = executaMovimento(origem, destino);

            if (estarEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce não pode se colocar em xeque!");
            }
            if(estarEmXeque(adversario(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;

            } if (testeXequemate(adversario(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudarJogador();
            }
        }
        private Peca rei(Cor cor)
        {
            foreach (Peca x in PecaEmJogo(cor)){
                if(x is Rei)
                {
                    return x;
                }
            
            }
            return null;
        }
        private Cor adversario(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }
        public Peca executaMovimento(Posicao origen, Posicao destino)
        {
            Peca p = tab.retirarPeca(origen);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarpeca(p, destino);
            if( pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;

        }

        public void desfazMovimento(Posicao origen, Posicao destino,Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if(pecaCapturada != null)
            {
                tab.colocarpeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarpeca(p, origen);
        }
        public HashSet<Peca> PecaEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
               
            }
            aux.ExceptWith(pecasCaputuradas(cor));
            return aux;          
        }
        public HashSet<Peca> pecasCaputuradas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public void colocarNovaPeca(char coluna,int linha, Peca peca)
        {
            tab.colocarpeca(peca, new  PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);

        }
        public bool testeXequemate(Cor cor)
        {
            if (!estarEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in PecaEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossisveil();
                for (int i = 0; i < tab.Linhas; i++)
                {
                    for (int j = 0; j < tab.Linhas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pegaCapturada = executaMovimento(x.posicao, destino);
                            bool testeXeque = estarEmXeque(cor);

                            desfazMovimento(origem, destino, pegaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }

                }
            }
              return true;
           
        }
        public bool estarEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor : " + cor + "no tabuleiro");
            }
            foreach (Peca x in PecaEmJogo(adversario(cor)))
            {
                bool[,] mat = x.movimentosPossisveil();
                if (mat[R.posicao.Linha, R.posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
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
            Console.WriteLine(origem);
            Console.WriteLine(destino);
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

        private void colocarPecas()
        {


            colocarNovaPeca('b',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('a',1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b',1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c',1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d',1, new Dama(tab, Cor.Branca));
            colocarNovaPeca('e',1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('f',1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g',1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h',1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('c',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('d',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('e',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('f',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('g',2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('h',2, new Peao(tab, Cor.Branca));


            colocarNovaPeca('a',7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('a',8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b',8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c',8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d',8, new Dama(tab, Cor.Preta));
            colocarNovaPeca('e',8, new Rei(tab, Cor.Preta));
            colocarNovaPeca('f',8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g',8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h',8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b',7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('c',7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('d',7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('e',7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('f',7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('g',7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('h',7, new Peao(tab, Cor.Preta));


        }
    }
}
