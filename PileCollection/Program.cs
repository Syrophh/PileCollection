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
            try
            {
                //TestePileVidePleine(5);
                //TestePileVidePleine(0);
                TesteEmpiler(5);
                TesteEmpiler(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Fin du programme, Appuyez sur unr touche pour terminer");
            Console.ReadKey();
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
            pUnePile.tabElem = new ArrayList();
            if (PNbElemt > 0)
            {
                pUnePile.maxElt = PNbElemt;
            }
            if (PNbElemt < 0)
            {
                pUnePile.maxElt = Math.Abs(PNbElemt);
            }
            if (PNbElemt == 0)
            {
                throw new Exception("maxElt ne peut pas être nul");
            }
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

        ///<summary>
        ///Test de la méthode Empiler
        /// </summary>
        /// <param name="nbElements">Nombre d'éléments maximum de la pile</param>
        static void TesteEmpiler(int nbElemets)
        {
            Pile unePile = new Pile();
            InitPile(ref unePile, nbElemets);
            Empiler(ref unePile, 2);
            Empiler(ref unePile, 14);
            Empiler(ref unePile, 6);
        }

        ///<summary>
        ///Renvoie la valeur située au sommet de la pile.
        ///Si la pile est vide, la méthode déclenche une Exception
        /// </summary>
        /// <param name="pUnePile">Pile à partir de laquelle il faut dépiler</param>
        /// <returns>Valeur dépilée</returns>
        static object Depiler(ref Pile pUnePile)
        {
            if (!PileVide(pUnePile))
            {
                pUnePile.tabElem.;
            }
        }
    }
}
