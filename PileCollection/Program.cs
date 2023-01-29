using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PileCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    //TestePileVidePleine(5);
            //    //TestePileVidePleine(0);
            //    //TesteEmpiler(5);
            //    //TesteEmpiler(2);
            //    TestEmpilerDepiler(5);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.WriteLine("Fin du programme, Appuyez sur une touche pour terminer");
            //TestConversion();
            Console.WriteLine(RecupereLoremIpsum(3));
            try
            {
                TesteInversePhrase();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Fin du programme, Appuyez sur une touche pour terminer");
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
                int result = (int) pUnePile.tabElem[pUnePile.tabElem.Count - 1];
                pUnePile.tabElem.RemoveAt(pUnePile.tabElem.Count-1);
                return result;
            }
            else
            {
                throw new Exception("Pile vide, impossible de dépiler un élément");
            }
        }

        ///<summary>
        ///Test D'empiler - dépiler
        /// </summary>
        /// <param name="nbElements">Nombre d'éléments maximum de la pile</param>
        static void TestEmpilerDepiler(int nbElements)
        {
            try
            {
                Pile unePile = new Pile();
                InitPile(ref unePile, 5);
                Empiler(ref unePile, 2);
                Empiler(ref unePile, 22);
                int valeurDepilee = (int)Depiler(ref unePile);
                Console.WriteLine("valeur dépilée : " + valeurDepilee);
                Empiler(ref unePile, 17);
                valeurDepilee = (int)Depiler(ref unePile);
                valeurDepilee = (int)Depiler(ref unePile);
                valeurDepilee = (int)Depiler(ref unePile);
                valeurDepilee = (int)Depiler(ref unePile);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Convertit un nombre de base 10 en base 8
        /// </summary>
        /// <param name="pNbElements">Nombre d'éléments de la pile</param>
        /// <param name="pNNbAConvertir">Nombre à convertir</param>
        /// <param name="pNewbase">Nouvelle base du nombre</param>
        /// <returns></returns>
        static string Convertir(int pNbElements, int pNbAConvertir, Int32 pNewbase)
        {
            String resultat = "";
            int premierNombre = pNbAConvertir;
            Pile pileConvertion = new Pile();
            InitPile(ref pileConvertion, pNbElements);
            while (pNbAConvertir != 0 && !PilePleine(pileConvertion))
            {
                Empiler(ref pileConvertion, pNbAConvertir % pNewbase);
                pNbAConvertir /= pNewbase;
            }

            if (pNbAConvertir != 0)
            {
                return "Impossible de convertir, la pile est trop petite";
            }
            else
            {
                while (!PileVide(pileConvertion))
                {
                    int nb = (int)Depiler(ref pileConvertion);
                    if (nb < 10)
                    {
                        resultat += Convert.ToString(nb);
                    }
                    else
                    {
                        resultat += nb.ToString("X");
                    }
                }
                return "La valeur de " + premierNombre + " (base 10) vaut " + resultat + " en base " + pNewbase;
            }
        }

        ///<summary>
        ///Test de la méthode Conversion(...)
        ///Cette méthode permet la saisie des valeurs utiles à la conversion:
        ///nombre d'éléments de la collection,
        ///nombre à convertir,
        ///nouvelle base
        /// </summary>
        static void TestConversion()
        {
            string nNombre = "";
            int elements = 0;
            int nombre = 0;
            int nBase = 0;
            Console.WriteLine("Veuillez entrer le nombre d'éléments : ");
            elements = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer le nombre à convertir : ");
            nombre = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez entrer la nouvelle base entre 2 et 16 : ");
            nBase = Convert.ToInt32(Console.ReadLine());
            nNombre = Convertir(elements, nombre, nBase);
            Console.WriteLine(nNombre);
        }



        static String RecupereLoremIpsum(int nbParagraphes)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/text"));
            String url = $"https://loripsum.net/api/{nbParagraphes}/short/plaintext";
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;

                return responseBody;
            }
            else
            {
                throw new Exception("Erreur API : " + response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        static void TestSplit()
        {
            String phrase = "Il fait toujours beau à Toulon";
            var tab = phrase.Split(' ');

            string valeurs = "rue;avenue;boulevard;place";
            tab = valeurs.Split(';');
        }

        static string InversePhrase(String phrase)
        {
            Pile maPile = new Pile();
            InitPile(ref maPile, 200);
            var tab = phrase.Split(' ');
            foreach(string mot in tab)
            {
                Empiler(ref maPile, mot);
            }
            String message = "";
            while (!PileVide(maPile))
            {
                message += " " + Depiler(ref maPile);
            }
            return message;
        }

        static void TesteInversePhrase()
        {
            try
            {
                String phrase = RecupereLoremIpsum(3);
                Console.WriteLine(phrase);
                String phraseInversee = InversePhrase(phrase);
                Console.WriteLine("\n Version Pile");
                Console.WriteLine(phraseInversee);
                phraseInversee = InversePhraseMieux(phrase);
                Console.WriteLine("\n Version Améliorée");
                Console.WriteLine(phraseInversee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static string InversePhraseMieux(String phrase)
        {
            
            var tab = phrase.Split(' ');
            Array.Reverse(tab);
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                Console.Write(tab[i] + "" + ' ');
            }
            return phrase;
        }

    }
}
