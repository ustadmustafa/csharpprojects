using System.Collections;

namespace integerikililerintoplami;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Girilecek integer sayisini yaz.");
        int n;
        n = int.Parse(Console.ReadLine());
        ArrayList sayiDizisi = new ArrayList();
        for(int i = 0; i < n ; i++){
            sayiDizisi.Add(int.Parse(Console.ReadLine()));

        }
        integerikililer(sayiDizisi);
        

        
    }

    static void integerikililer(ArrayList sayiDizisi){
        /*foreach (int item in sayiDizisi)
        {
            Console.WriteLine(item + "***");
        }*/

        int ilkSayi;
        int ikinciSayi;

        for(int i=0;i < sayiDizisi.Count;i++){
            ilkSayi = (int) sayiDizisi[i];
            ikinciSayi = (int) sayiDizisi[i+1];
            i++;
            //Console.WriteLine("***" + ilkSayi + "***" + ikinciSayi);

            if(ilkSayi == ikinciSayi){
                Console.Write(Math.Pow(ilkSayi*ikinciSayi,2) + " ");
            }else{
                Console.Write(ilkSayi + ikinciSayi + " ");
            }
        }

    }
}
