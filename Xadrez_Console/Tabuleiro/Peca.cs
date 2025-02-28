

namespace Tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public tabuleiro Tab { get; protected set; }



        public Peca(tabuleiro tab, Cor cor){
            posicao = null;
            Tab = tab;
            this.cor = cor;
            QteMovimentos = 0;
    }
        public void incrementarQteMovimentos()
        {
            QteMovimentos++;

        }

}
}
