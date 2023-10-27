using System.Collections;

namespace SessizHarf;

class Program
{
    static void Main(string[] args)
    {
        /*Verilen string ifade içerisinde yanyana 2 tane sessiz varsa ekrana true, yoksa false yazdıran console uygulamasını yazınız.

        Örnek: Input: Merhaba Umut Arya

        Output: True False True*/
        fonksiyon("Merhaba");
        fonksiyon("Umut");
        fonksiyon("Arya");
        


    }

    public static void fonksiyon(string s){
        string sessizHarfler = "bcçdfgğhjklmnprsştvyz";
        for (int i = 0; i < s.Length -1; i++)
        {
            if(sessizHarfler.Contains(s[i].ToString().ToLower()) && sessizHarfler.Contains(s[i+1].ToString().ToLower())){
                Console.WriteLine("True");
                return;
            }
        }
        Console.WriteLine("False");
        return;
    }

    
}
