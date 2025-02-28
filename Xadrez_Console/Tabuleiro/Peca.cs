

namespace Tabuleiro
{
  abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public tabuleiro tab { get; protected set; }



        public Peca(tabuleiro tab, Cor cor){
            posicao = null;
           this.tab = tab;
            this.cor = cor;
            QteMovimentos = 0;
    }
        public void incrementarQteMovimentos()
        {
            QteMovimentos++;

        }
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossisveil();
            for( int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Coluna; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                
                }
            }
            return false;

        }
        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossisveil()[pos.Linha, pos.Coluna];

        }
        public abstract bool[,] movimentosPossisveil();

}
}
