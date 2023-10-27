namespace MutlakKareAlma;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sayıları boşlukla ayırarak girin: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');

        int sumOfDifferences = 0;
        int sumOfSquaredDifferences = 0;

        foreach (string numberString in numbers){
            if(int.TryParse(numberString,out int number)){
                int difference = Math.Abs(67 - number);

                if(number < 67){
                    sumOfDifferences += difference;
                }else{
                    sumOfSquaredDifferences += difference * difference;
                }
            }else{
                Console.WriteLine("Geçersiz sayi: " + numberString);
            }
        }

        Console.WriteLine("Küçük olanların farklarının toplamı: " +sumOfDifferences);
        Console.WriteLine("Büyük olanların farkların mutlak kareleri toplamı: " + sumOfSquaredDifferences);
        
            
        
     }
}
