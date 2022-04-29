using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Verenchuk;
using System.IO;
namespace UnitTestProject
{
    [TestClass]
    public class VigenerFileTest1
    {
        [TestInitialize]
        public void Init()
        {
            File.WriteAllText("empty_file", "");
            File.WriteAllText("crypted_file", cryptedText, System.Text.Encoding.Default);
        }

        [TestMethod]
        public void EmptyFile()
        {
            Assert.AreEqual(FileVigenere.ReadFromFile("empty_file", "л"), "");
            FileVigenere.WriteOnFile("empty_file1", "", "л");
            Assert.AreEqual(ReadFromFile("empty_file1"), "");
            FileVigenere.WriteOnFile("empty_file2", "", null);
            Assert.AreEqual(ReadFromFile("empty_file2"), "");
        }
        [TestMethod]
        public void NotExistFile()
        {
            Assert.ThrowsException<Exception>(() => FileVigenere.ReadFromFile("1234", key));
            Assert.ThrowsException<Exception>(() => FileVigenere.ReadFromFile("C:\\Windows", key));
        }
        [TestMethod]
        public void CryptAndDecrypt()
        {
            Assert.AreEqual(FileVigenere.ReadFromFile("crypted_file", key), unCryptedText);
            FileVigenere.WriteOnFile("crypted_file1", unCryptedText, key);
            Assert.AreEqual(FileVigenere.ReadFromFile("crypted_file1", key), unCryptedText);
        }

        [TestMethod]
        public void WriteWithoutKey()
        {
            FileVigenere.WriteOnFile("withoutCrypt", unCryptedText, null);
            Assert.AreEqual(ReadFromFile("withoutCrypt"), unCryptedText);
            Assert.AreEqual(FileVigenere.ReadFromFile("withoutCrypt", null), unCryptedText);
        }

        private string cryptedText = $"бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!!\n у ъящэячэц ъэюоык, едщ бдв саэацкшгнбяр гчеа кчфцшубп цу ьгщпя вщвсящ, эвэчрысй юяуъщнщхо шпуъликугбз чъцшья с цощъвчщ ъфмес ю лгюлэ ёъяяр! с моыящш шпмоец щаярдш цяэубфъ аьгэотызуа дщ, щръ кй юцкъщчьуац уыхэцэ ясч юбюяуяг ыовзсгюамщщ.внютвж тхыч эядкъябе цн юкъль, мэсццогл шяьфыоэьь ть эщсщжнашанэ ыюцен, уёюяыцчан мах гъъьуун шпмоыъй ч яяьпщъхэтпык яущм бпйэае! чэьюмуд, оээ скфч саьбрвчёыа эядуцйт ъ уьгфщуяяёу фси а эацэтшцэч юпапёи, ьь уъубфмч ысь хффы ужц чьяцнааущ эгъщйаъф, ч п эиттпьк ярвчг гмубзньцы! щб ьшяо шачюрэсч FirstLineSoftware ц ешчтфщацдпбр шыыь, р ыоф ячцсвкрщве бттй а ядсецсцкюкх эшашёрэсуъ якжще увюгщр в# уфн ысвчюпжзцж! чй ёюычъ бщххыибй еьюхечр п хкъмэншёцч юятщвфцшчщ с хчю ъэ ч аачсюсчыщачрняун в шъюьэжцясиьццч агфуо ацаьяычсцы .Net, чэбф ыуюбпьщо с чыдпяхбцйг щктрж!";
        private string unCryptedText = $"поздравляю, ты получил исходный текст!!!\n в принципе понять, что тут используется шифр виженера не особо трудно, основная подсказка заключается именно в наличии ключа у этого шифра! в данной задаче особый интерес составляет то, как вы реализуете именно сам процесс расшифровки.теперь дело осталось за малым, доделать программу до логического конца, выполнить все условия задания и опубликовать свою работу! молодец, это были достаточно трудные и интересные два с половиной месяца, но впереди нас ждет еще множество открытий, и я надеюсь общих свершений! от лица компании FirstLineSoftware и университета итмо, я рад поздравить тебя с официальным окончанием наших курсов с# для начинающих! мы хотим пожелать успехов в дальнейшем погружении в мир ит и программирования с использованием стека технологий .Net, море терпения и интересных задач!";
        private string key = $"скорпион";
        
        private string ReadFromFile(string nameFIle)
        {
            return File.ReadAllText(nameFIle, System.Text.Encoding.Default);
        }

    }
}
