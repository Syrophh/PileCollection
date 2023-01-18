using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PileCollection
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        struct Pile
        {
            public int maxElt; // nombre maximum d'éléments de la pile
            public ArrayList tabElem; //tableau [0..Maxelt] d'entiers
        }

        /// <summary>
        /// initialise une nouvelle variable de type Pile
        /// cette méthode :
        ///     initialise la variable maxElt
        ///     instancie la collection de type ArrayList tabElem
        /// </summary>
        /// <param name="pUnePile">Pile à initialiser</param>
        /// <param name="PNbElemt">Nombre d'élément maxi de la Pile</param>
        static void InitPile(ref Pile pUnePile, int PNbElemt)
        {

        }
    }
}
