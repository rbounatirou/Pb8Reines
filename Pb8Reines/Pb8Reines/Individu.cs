namespace Pb8Reines
{
    public class Individu
    {
        private int[] positionReines;

        public int[] PositionReines { get => positionReines; }

        public Individu()
        {
            List<int> position = new();
            // PAR DEFAUT 
            for (int i = 0; i < 8; i++)
            {
                position.Add(Alea.GetNombreAleatoire(0, 7));
            }
            positionReines = position.ToArray();
        }

        public Individu(int[] positions)
        {
            if (positions.Length != 8)
                throw new Exception("Erreur doit avoir une longueur de 8");
            positionReines = positions;
        }

        public int Fitness()
        {
            int score = 0;
            for (int i = 0; i < 8; i++)
            {
                if (CheckIfIndexIsOk(i))
                    score++;
            }
            return score;
        }

        private bool CheckIfIndexIsOk(int index)
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
            return inLine == 1 && inDiag == 1;
            
        }

        public Individu CrossOver(Individu _indivuAvecLequelFaireReproduction)
        {
            int curseur = Alea.GetNombreAleatoire(0, 6);
            bool poidsFort = Alea.GetNombreAleatoire(0, 1) == 0;
            List<int> positionEnfant = new();
            Individu curentParentGene;
            for (int i = 0; i < 8; i++)
            {
                if (i < curseur)
                {
                    curentParentGene = poidsFort ? this : _indivuAvecLequelFaireReproduction;
                } else
                {
                    curentParentGene = poidsFort ? _indivuAvecLequelFaireReproduction : this;
                }
                positionEnfant.Add(curentParentGene.PositionReines[i]);
                
            }
            return new Individu(positionEnfant.ToArray());
        }

        public void Mutate(int probabiliteEnPourcent)
        {
            int score;
            for (int i =0; i < 8; i++)
            {
                score =  Alea.GetNombreAleatoire(1, 100);
                if (score <= probabiliteEnPourcent)
                {
                    positionReines[i] = Alea.GetNombreAleatoire(0, 7);
                }
            }
        }
    }
}