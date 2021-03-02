using System;
using System.Text;

namespace cv03_bpc_oop
{
    class StringStatistics
    {
        private string text;
        
        public int CountWords()
        {
            return text.Split(' ', '\n').Length;
        }

        public int CountRows()
        {
            return text.Split('\n').Length;
        }

        public int CountSentences()
        {
            char[] letters = text.ToCharArray();
            int sentencesCounter = 1;
            for(int index = 0; index < (letters.Length - 2); index ++)
            {
                if ((letters[index] == '.' ||
                    letters[index] == '!' ||
                    letters[index] == '?') &&
                    Char.IsWhiteSpace(letters[index + 1]) &&
                    Char.IsUpper(letters[index + 2]))
                    sentencesCounter++;
            }
            return sentencesCounter;
            //return text.Split('.', '!', '?').Length;
        }
        
        private static string getOnlyLetters(string pollutedText)
        {
            char[] separatedLetters = pollutedText.ToCharArray();

            StringBuilder sb = new StringBuilder("");
            for (int letterIndex = 0; letterIndex < separatedLetters.Length; letterIndex++)
            {
                if (Char.IsLetter(separatedLetters[letterIndex]))
                {
                    sb.Append(separatedLetters[letterIndex]);
                }
            }

            return sb.ToString();
        }

        public string[] LongestWords()
        {
            string[] separatedWords = text.Split(' ', '\n');

            for (int wordIndex = 0; wordIndex < separatedWords.Length; wordIndex++)
                separatedWords[wordIndex] = getOnlyLetters(separatedWords[wordIndex]);

            //Vyhledání maximální délky slova a určení velikosti výstupního pole slov
            int maxWordLen = 0, outputWordsCount = 0;
            for (int wordIndex = 0; wordIndex < separatedWords.Length; wordIndex++)
            {
                if (separatedWords[wordIndex].Length > maxWordLen)
                {
                    maxWordLen = separatedWords[wordIndex].Length;
                    outputWordsCount = 1;
                }
                else if (separatedWords[wordIndex].Length == maxWordLen)
                {
                    outputWordsCount++;
                }
            }

            //Odfiltrování slov neodpovídajících maximální délce slova
            string[] outputWords = new string[outputWordsCount];
            int outputWordsIndex = 0;
            for (int wordIndex = 0; wordIndex < separatedWords.Length; wordIndex++)
            {
                if (separatedWords[wordIndex].Length == maxWordLen)
                {
                    outputWords[outputWordsIndex] = separatedWords[wordIndex];
                    outputWordsIndex++;
                }
            }

            return outputWords;
        }

        public string[] ShortestWords()
        {
            string[] separatedWords = text.Split(' ', '\n');

            for (int wordIndex = 0; wordIndex < separatedWords.Length; wordIndex++)
                separatedWords[wordIndex] = getOnlyLetters(separatedWords[wordIndex]);

            //Vyhledání minimální délky slova a určení velikosti výstupního pole slov
            int minWordLen = -1, outputWordsCount = 0;
            for (int wordIndex = 0; wordIndex < separatedWords.Length; wordIndex++)
            {
                if (separatedWords[wordIndex].Length < minWordLen || minWordLen == -1)
                {
                    minWordLen = separatedWords[wordIndex].Length;
                    outputWordsCount = 1;
                }
                else if (separatedWords[wordIndex].Length == minWordLen)
                {
                    outputWordsCount++;
                }
            }

            //Odfiltrování slov neodpovídajících maximální délce slova
            string[] outputWords = new string[outputWordsCount];
            int outputWordsIndex = 0;
            for (int wordIndex = 0; wordIndex < separatedWords.Length; wordIndex++)
            {
                if (separatedWords[wordIndex].Length == minWordLen)
                {
                    outputWords[outputWordsIndex] = separatedWords[wordIndex];
                    outputWordsIndex++;
                }
            }

            return outputWords;
        }

        public string[] MostCommonWords()
        {
            string[] separatedWords = text.ToLower().Split(' ', '\n');

            for (int wordIndex = 0; wordIndex < separatedWords.Length; wordIndex++)
                separatedWords[wordIndex] = getOnlyLetters(separatedWords[wordIndex]);

            int[] matchCount = new int[separatedWords.Length];

            //Reset počítadel
            foreach (int index in matchCount) matchCount[index] = 0;

            //Prochází všechna slova v poli a hledá shody se slovy za ním
            //V případě nálezu inkrementuje počítadlo výskytu pro dané slovo a všechny další výskyty postupně vymaže,
            //aby nebyly na výstupu duplicitně
            for (int mainWordIndex = 0; mainWordIndex < separatedWords.Length - 1; mainWordIndex++)
            {
                if (String.IsNullOrEmpty(separatedWords[mainWordIndex])) continue;

                for (int wordIndex = mainWordIndex + 1; wordIndex < separatedWords.Length; wordIndex++)
                {
                    if (separatedWords[mainWordIndex] == separatedWords[wordIndex])
                    {
                        matchCount[mainWordIndex]++;
                        separatedWords[wordIndex] = String.Empty;
                    }
                }
            }

            //Vyhledání maximální hodnoty počítadla a určení velikosti výstupního pole slov
            int maxCount = 0, outputWordsCount = 0;
            for (int wordIndex = 0; wordIndex < matchCount.Length; wordIndex++)
            {
                if (matchCount[wordIndex] > maxCount)
                {
                    maxCount = matchCount[wordIndex];
                    outputWordsCount = 1;
                }
                else if (matchCount[wordIndex] == maxCount)
                {
                    outputWordsCount++;
                }
            }

            //Odfiltrování slov neodpovídajících maximálnímu výskytu
            string[] outputWords = new string[outputWordsCount];
            int outputWordsIndex = 0;
            for (int wordIndex = 0; wordIndex < matchCount.Length; wordIndex++)
            {
                if (matchCount[wordIndex] == maxCount)
                {
                    outputWords[outputWordsIndex] = separatedWords[wordIndex];
                    outputWordsIndex++;
                }
            }

            return outputWords;
        }

        public string[] SortWords()
        {
            string[] separatedWords = text.Split(' ', '\n');

            for (int wordIndex = 0; wordIndex < separatedWords.Length; wordIndex++)
                separatedWords[wordIndex] = getOnlyLetters(separatedWords[wordIndex]);

            Array.Sort(separatedWords, System.Collections.CaseInsensitiveComparer.Default);
            return separatedWords;
        }

        public StringStatistics(string text)
        {
            this.text = text;
        }
    }
}
