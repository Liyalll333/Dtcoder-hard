using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigener
{
    public class Vigener
    {
        static char[] characters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                                'э', 'ю', 'я' };
        static private int N = characters.Length;
        public Vigener()
        {
        }
        private static bool IsSymbolExist(char symbol)
        {
            foreach(char c in characters)
                if(c == symbol)
                    return true;
            return false;
        }

        static public string Decode(string input, string keyword)
        {
            if (keyword == null)
                return input;

            ValidateKeyword(keyword);
            keyword = keyword.ToLower();
            string result = "";
            int keyword_index = 0;

            foreach (char old_symbol in input)
            {
                char symbol = Char.ToLower(old_symbol);
                if (!IsSymbolExist(symbol))
                {
                    result += old_symbol;
                    continue;
                }

                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += old_symbol == symbol ? characters[p] : Char.ToUpper(characters[p]);

                keyword_index++;

                if (keyword_index == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        static public string Encode(string input, string keyword)
        {
            if(keyword == null)
                return input;

            ValidateKeyword(keyword);
            keyword = keyword.ToLower();

            string result = "";

            int keyword_index = 0;

            foreach (char old_symbol in input)
            {
                char symbol = Char.ToLower(old_symbol);

                if (!IsSymbolExist(symbol))
                {
                    result += old_symbol;
                    continue;
                }

                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;


                result += old_symbol == symbol ? characters[c] : Char.ToUpper(characters[c]);

                keyword_index++;

                if ((keyword_index) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }
        static private void ValidateKeyword(string keyword)
        {
            if(keyword.Length == 0)
                throw new Exception("Пустой ключ");

            foreach (char symbol in keyword)
                if (!IsSymbolExist(symbol))
                    throw new Exception("Невалидный ключ");
        }
    }
}
