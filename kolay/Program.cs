using System.Collections;
using System.Collections.Generic;

namespace kolay;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine(OrtalamaHesapla(5));

        //TriangleDrawer.DrawTriangle(8);

        //CircleDrawer.DrawCircle(5);

        //Algoritma("Mustafa,2");

        Console.WriteLine(SwapAdjacentCharacters("sick of this flesh prison"));






    }

    static double OrtalamaHesapla(int a){
        double sonuc;
        double toplam = 0;
        List<int> fibonacciDizisi = new List<int>();
        fibonacciDizisi.Add(1);
        fibonacciDizisi.Add(2);
        for (int i = 0; i < a-2; i++)
        {
            fibonacciDizisi.Add(fibonacciDizisi[i] + fibonacciDizisi[i+1]);
        }
        foreach (var item in fibonacciDizisi)
        {
            toplam += item;
        }
        sonuc = toplam / a;
        return sonuc;
    }

    class TriangleDrawer
{
    public static void DrawTriangle(int height)
    {
        for (int i = 1; i <= height; i++)
        {
            DrawSpaces(height - i);
            DrawStars(2 * i - 1);
            Console.WriteLine();
        }
    }

    private static void DrawSpaces(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(" ");
        }
    }

    private static void DrawStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write("*");
        }
    }
}

class CircleDrawer
{
    public static void DrawCircle(double radius)
    {
        int width = (int)Math.Ceiling(2 * radius);
        int height = (int)Math.Ceiling(radius);

        for (int i = 0; i <= 2 * height; i++)
        {
            for (int j = 0; j <= width; j++)
            {
                double distance = Math.Sqrt(Math.Pow(i - height, 2) + Math.Pow(j - radius, 2));
                if (Math.Abs(distance - radius) < 0.5)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}

    static void Algoritma(string input){
        string[] parts = input.Split(',');
        string text = parts[0];
        int index = int.Parse(parts[1]);
        string result;

        result = text.Remove(index,1);
        Console.WriteLine(result);
    }

    static string SwapAdjacentCharacters(string input)
    {
        char[] charArray = input.ToCharArray();

        for (int i = 1; i < charArray.Length; i += 2)
        {
            char temp = charArray[i - 1];
            charArray[i - 1] = charArray[i];
            charArray[i] = temp;
        }

        return new string(charArray);
    }

 


}
