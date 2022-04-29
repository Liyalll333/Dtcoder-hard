using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Vigener;

namespace UnitTestProject
{
    [TestClass]
    public class VigenerTest
    {
        [TestMethod]
        public void TestExcetpionKeyInvalid()
        {
            string[] arrayValue = { "", "1", "С", " ", "привЕт", "Привет", "Привет " };
            foreach(string value in arrayValue)
            {
                Assert.ThrowsException<Exception>(() => Vigener.Vigener.Decode("Некоторый текст", value));
                Assert.ThrowsException<Exception>(() => Vigener.Vigener.Encode("Некоторый текст", value));
            }
        }
        [TestMethod]
        public void CheckDecode()
        {
            string cryptedText = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!! ";
            Assert.AreEqual("поздравляю, ты получил исходный текст!!! ", Vigener.Vigener.Decode(cryptedText, "скорпион"));
            Assert.AreNotEqual("поздравляю, ты получил исходный текст!!! ", Vigener.Vigener.Decode(cryptedText, "зкорпион"));
            Assert.AreNotEqual("поздравляю, ты получил исходный текст!!! ", Vigener.Vigener.Decode(cryptedText, "скорпиов"));
            Assert.AreNotEqual("поздравляю, ты получил исходный текст!!! ", Vigener.Vigener.Decode(cryptedText, "скорнион"));
        }
        [TestMethod]
        public void CheckEncode()
        {
            string unCryptedText = "поздравляю, ты получил исходный текст!!! ";
            Assert.AreEqual("бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!! ", Vigener.Vigener.Encode(unCryptedText, "скорпион"));
            Assert.AreNotEqual("бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!! ", Vigener.Vigener.Encode(unCryptedText, "зкорпион"));
            Assert.AreNotEqual("бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!! ", Vigener.Vigener.Encode(unCryptedText, "скорпиов"));
            Assert.AreNotEqual("бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!! ", Vigener.Vigener.Encode(unCryptedText, "скорнион"));
        }

    }
}
