using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Verenchuk
{
    public class FileVigenere
    {
        static public string ReadFromFile(string filename, string keyword)
        {
            string crypted;
            try
            {
                crypted = File.ReadAllText(filename, Encoding.Default);
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при чтении файла: " + e.Message);
            }
            return Vigener.Vigener.Decode(crypted, keyword);
        }

        static public void WriteOnFile(string filename, string data, string keyword)
        {
            string crypted = Vigener.Vigener.Encode(data, keyword);
            try
            {
                File.WriteAllText(filename, crypted, Encoding.Default);
            }
            catch(Exception e)
            {
                throw new Exception("Ошибка при записи файла: " + e.Message);
            }
        }
    }
}
