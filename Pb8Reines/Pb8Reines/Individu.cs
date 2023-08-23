namespace Pb8Reines
{
    public class Individu
    {
        private static readonly int TAILLE = 8;
        private int[] positionReines;

        public int[] PositionReines { get => positionReines; }

        public Individu()
        {
            List<int> position = new();
            // PAR DEFAUT 
            for (int i = 0; i < TAILLE; i++)
            {
                position.Add(Alea.GetNombreAleatoire(0, TAILLE-1));
            }
            positionReines = position.ToArray();
        }

        public Individu(int[] positions)
        {
            if (positions.Length != TAILLE)
                throw new Exception("Erreur doit avoir une longueur de " + TAILLE);
            positionReines = positions;
        }

        public int Fitness()
        {
            int score = 0;
            for (int i = 0; i < TAILLE; i++)
            {
                score += CalculateScoreForQueen(i);
            }
            return score;
        }

        private int CalculateScoreForQueen(int index)
        {
            int positionBase = positionReines[index];
            int inLine = 0;
            int inDiag = 0;
            for (int i = 0; i < positionReines.Length; i++)
            {
                if (positionReines[i] == positionBase)
                {
                    inLine++;
                }
                if (positionReines[i] == positionBase - (index-i) ||
                    positionReines[i] == positionBase + (index-i))
                {
                    inDiag++;
                }
            }
            return 7 - ((inLine -1) + (inDiag-1));
            
        }

        public Individu CrossOver(Individu _indivuAvecLequelFaireReproduction)
        {
            int curseur = Alea.GetNombreAleatoire(0, (TAILLE-2));
            bool poidsFort = Alea.GetNombreAleatoire(0, 1) == 0;
            List<int> positionEnfant = new();
            Individu currentParentGene;
            for (int i = 0; i < TAILLE; i++)
            {
                if (i < curseur)
                {
                    currentParentGene = poidsFort ? this : _indivuAvecLequelFaireReproduction;
                } else
                {
                    currentParentGene = poidsFort ? _indivuAvecLequelFaireReproduction : this;
                }
                positionEnfant.Add(currentParentGene.PositionReines[i]);
                
            }
            return new Individu(positionEnfant.ToArray());
        }

        public void Mutate(int probabiliteEnPourcent)
        {
            int score;
            for (int i =0; i < TAILLE; i++)
            {
                score =  Alea.GetNombreAleatoire(1, 100);
                if (score <= probabiliteEnPourcent)
                {
                    positionReines[i] = Alea.GetNombreAleatoire(0, TAILLE-1);
                }
            }
        }
    }
}