using System;

namespace cv03_bpc_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            string testingText = "Toto je retezec predstavovany nekolika radky,\n"
                                         + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
                                         + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
                                         + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
                                         + "posledni veta!";

            StringStatistics stat = new StringStatistics(testingText);

            Console.WriteLine("{0}", testingText);

            Console.WriteLine();

            Console.WriteLine("Počet slov: {0:d}", stat.CountWords());
            Console.WriteLine("Počet řádků: {0:d}", stat.CountRows());
            Console.WriteLine("Počet vět: {0:d}", stat.CountSentences());

            string[] outputText = stat.LongestWords();
            Console.Write("Nejdelší slova: ");
            for (int arrayIndex = 0; arrayIndex < stat.LongestWords().Length; arrayIndex ++)
            {
                Console.Write("{0}", stat.LongestWords()[arrayIndex]);
                if (arrayIndex != (stat.LongestWords().Length - 1))
                    Console.Write(", ");
            }
            Console.WriteLine();

            outputText = stat.ShortestWords();
            Console.Write("Nejkratší slova: ");
            for (int arrayIndex = 0; arrayIndex < outputText.Length; arrayIndex++)
            {
                Console.Write("{0}", outputText[arrayIndex]);
                if (arrayIndex != (outputText.Length - 1))
                    Console.Write(", ");
            }
            Console.WriteLine();

            outputText = stat.MostCommonWords();
            Console.Write("Nejčastější slova: ");
            for (int arrayIndex = 0; arrayIndex < outputText.Length; arrayIndex++)
            {
                Console.Write("{0}", outputText[arrayIndex]);
                if (arrayIndex != (outputText.Length - 1))
                    Console.Write(", ");
            }
            Console.WriteLine();

            outputText = stat.SortWords();
            Console.Write("Slova dle abecedy: ");
            for (int arrayIndex = 0; arrayIndex < outputText.Length; arrayIndex++)
            {
                Console.Write("{0}", outputText[arrayIndex]);
                if (arrayIndex != (outputText.Length - 1))
                    Console.Write(", ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
