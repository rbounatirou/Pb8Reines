using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb8Reines
{
    public class Alea
    {
        private static Random rnd;
        private Alea()
        {
            rnd = new Random();
        }

        public static int GetNombreAleatoire(int min, int max)
        {
            if (rnd == default(Random))
            {
                new Alea();
            }
            return rnd.Next(min, max + 1);
        }
    }
}
