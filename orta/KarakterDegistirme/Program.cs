namespace KarakterDegistirme;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input: ");
        string input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input) && input.Length >= 2)
        {
            char firstChar = input[0];
            char lastChar = input[input.Length - 1];

            // İlk ve son karakterlerin yerini değiştir
            char[] charArray = input.ToCharArray();
            charArray[0] = lastChar;
            charArray[input.Length - 1] = firstChar;

            string result = new string(charArray);

            Console.WriteLine("Output: " + result);
        }
        else
        {
            Console.WriteLine("Geçersiz giriş. Lütfen en az iki karakterden oluşan bir string girin.");
        }
    }
}
