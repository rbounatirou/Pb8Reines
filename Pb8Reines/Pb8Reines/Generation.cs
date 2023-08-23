using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb8Reines
{
    public class Generation
    {
        private int nbIndividu;
        private int tauxMutationPourcent;
        private List<Individu> sesIndividus;

        public int NbIndividu { get => nbIndividu; }
        public int TauxMutationPourcent { get =>  tauxMutationPourcent; }

        public List<Individu> Individus {  get => sesIndividus; }

        public Generation(int nb, int tauxMutation) 
        {
            this.nbIndividu = nb;
            this.tauxMutationPourcent = tauxMutation;
            sesIndividus = new List<Individu>();
            for (int i = 0; i < nbIndividu; i++)
            {
                sesIndividus.Add(new Individu());
            }
        }

        public Generation(Generation _generationFrom)
        {
            this.nbIndividu = _generationFrom.NbIndividu;
            this.tauxMutationPourcent = _generationFrom.TauxMutationPourcent;
            sesIndividus = new List<Individu>();
            Individu meilleur = _generationFrom.SortByFitness()[0];
            sesIndividus.Add(meilleur);
            for (int i = 1; i < _generationFrom.NbIndividu; i++)
            {
                Individu nouvelIndividu = meilleur.CrossOver(_generationFrom.Individus[i]);
                nouvelIndividu.Mutate(tauxMutationPourcent);

                sesIndividus.Add(nouvelIndividu);
            }
        }

        public List<Individu> SortByFitness()
        {
            sesIndividus.Sort((a, b) => a.Fitness() - b.Fitness());
            sesIndividus.Reverse();
            return sesIndividus;
        }
    }
}
