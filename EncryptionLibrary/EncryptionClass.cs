using System.Linq;

namespace EncryptionLibrary
{
    public class EncryptionClass
    {
        public static string EncryptDecrypt(string data, ushort key)
        {
            var symbols = data.ToArray(); //преобразуем строку в символы
            string result = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var symbol in symbols)  //выбираем каждый элемент из массива символов нашей строки
                result += Encryption(symbol, key);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return result;
        }

        public static char Encryption(char symbol, ushort key)
        {
            symbol = (char)(symbol ^ key); //Производим XOR операцию
            return symbol;
        }
    }
}
