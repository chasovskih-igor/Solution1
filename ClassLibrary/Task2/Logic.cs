using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Logic
    {
        public static string ReadFromFile(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                return sr.ReadToEnd();
            }
            catch
            {
                return "Error";
            }
        }
        public static string[] ColorWordsArray(string s)
        {
            string[] separators = { ",", ".", "!", "?", ";", ":", " ", "\n", "\t", "\r" };
            string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (IsLatAndNum(words[i]))
                {
                    count++;
                }
            }
            string[] colorWords = new string[count];
            int firstNull = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (IsLatAndNum(words[i]))
                {
                    colorWords[firstNull] = words[i];
                    firstNull++;
                    // Заведомо в тексте есть 1 подходящее слово. (Допустим оно первое). Нашли его. Данное условие позволяет не проходить по всей оставшейся части текста
                    if (firstNull == colorWords.Length) break;
                }
            }
            Console.WriteLine(Directory.GetCurrentDirectory());
            return colorWords;
        }

        public static bool IsLatAndNum(string word)
        {
            foreach (char x in word.ToCharArray())
            {
                if (!(!Char.IsControl(x) && (Char.IsDigit(x) || x >= 'a' && x <= 'z' || x >= 'A' && x <= 'Z')))
                {
                    return false;
                }
            }
            return true;
        }
        public static string[] DelNulls(string[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length != 0)
                {
                    count++;
                }
            }
            string[] emptyStrings = new string[count];
            int firstNull = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length != 0)
                {
                    emptyStrings[firstNull] = arr[i];
                    firstNull++;
                    if (firstNull == emptyStrings.Length) break;
                }
            }
            return emptyStrings;
        }
        public static void WriteToRichTextBox(RichTextBox textBox, string text)
        {
            string[] colorWords = ColorWordsArray(text);
            colorWords = DelNulls(colorWords);
            int poz = 0;
            if (colorWords.Length == 0)
            {
                textBox.AppendText(text);
            }
            else
                foreach (string s in colorWords)
                {
                    int t = text.IndexOf(s, poz);
                    textBox.AppendText(text.Substring(poz, t - poz));
                    textBox.SelectionColor = Color.Red;
                    textBox.AppendText(text.Substring(t, s.Length));
                    poz = t + s.Length;
                    textBox.SelectionColor = Color.Black;
                }

        }
    }
}
