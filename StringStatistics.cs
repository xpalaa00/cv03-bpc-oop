using System;

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
            //return text.Split('.', '!', '?').Length;
        }
        
        public StringStatistics(string text)
        {
            this.text = text;
        }
    }
}
