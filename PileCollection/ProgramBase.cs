namespace PileCollection
{
    internal class ProgramBase
    {

        private static string InversePhraseMieux(String phrase)
        {

            var tab = phrase.Split(' ');
            Array.Reverse(tab);
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                Console.Write(tab[i] + "" + ' ');
            }
        }
    }
}