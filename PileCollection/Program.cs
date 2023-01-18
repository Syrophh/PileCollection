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
            TestePileVidePleine(5);
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
            pUnePile.maxElt = PNbElemt;
            pUnePile.tabElem = new ArrayList ();
        }

        ///<summary>
        ///retourne un booléen indiquant si la pile est vide
        ///Une pile est vide si maxElt = 0
        /// </summary>
        /// <param name="pUnePile"></param>
        /// <returns></returns>
        static bool PileVide(Pile pUnePile)
        {
            return pUnePile.tabElem.Count == 0;
        }

        ///<summary>
        ///retourne un booléen indiquant si la pile est pleine
        ///Une pile est pleine si maxElt = pUnePile.tabElem.Count
        /// </summary>
        /// <param name="pUnePile"></param>
        /// <returns></returns>
        static bool PilePleine(Pile pUnePile)
        {
            return pUnePile.maxElt == pUnePile.tabElem.Count;
        }

        ///<summary>
        ///Cette méthode ajoute la valeur passée en paramètre au sommet de la pile
        ///SI la pile n'est pas pleine.
        ///Si la pile est pleine, déclenchement d'une exception
        /// </summary>
        /// <param name="pUnePile">pile sur laquelle il faut empiler</param>
        /// <param name="PObj">éléments à empiler</param>

        static void Empiler(ref Pile pUnePile, Object PObj)
        {
                if (!PilePleine(pUnePile))
                {
                    pUnePile.tabElem.Add(PObj);
                }
                else
                {
                    throw new Exception("Pile pleine, impossible d'empiler un élément");
                }
        }

        ///<summary>
        ///teste des méthodes PileVide et PilePleine
        /// </summary>
        /// <param name="nbElements">Nombre d'éléments maximum de la pile</param>
        static void TestePileVidePleine(int nbElements)
        {
            Pile unePile = new Pile();
            InitPile(ref unePile, nbElements);
            if (PileVide(unePile))
            {
                Console.WriteLine("la pile est vide");
            }
            else
            {
                Console.WriteLine("La pile n'est pas vide");
            }
            if (PilePleine(unePile))
            {
                Console.WriteLine("la pile est pleine");
            }
            else
            {
                Console.WriteLine("La pile n'est pas pleine");
            }
        }
    }
}
