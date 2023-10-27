namespace orta;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Geometrik Şekil Seçenekleri:");
        Console.WriteLine("1. Daire");
        Console.WriteLine("2. Üçgen");
        Console.WriteLine("3. Kare");
        Console.WriteLine("4. Dikdörtgen");

        Console.Write("Lütfen bir geometrik şekil seçin (1/2/3/4): ");

        if (int.TryParse(Console.ReadLine(), out int shapeChoice) && shapeChoice >= 1 && shapeChoice <= 4)
        {
            ShapeCalculator calculator = new ShapeCalculator();
            string shapeName = calculator.GetShapeName(shapeChoice);
            
            double[] sides = calculator.GetSides(shapeName);
            double dimension = calculator.GetDimension();
            
            double result = calculator.Calculate(shapeName, sides, dimension);
            string resultType = calculator.GetResultType(shapeName);

            Console.WriteLine($"{resultType} hesaplandı: {result}");
        }
        else
        {
            Console.WriteLine("Geçersiz seçenek. Lütfen 1-4 arasında bir seçenek girin.");
        }
    }

    class ShapeCalculator{
        public string GetShapeName(int choice){
            switch (choice){
                case 1:
                    return "Daire";
                case 2:
                    return "Üçgen";
                case 3:
                    return "Kare";
                case 4:
                    return "Dikdörtgen";
                default:
                    return string.Empty;
            }
        }

        public double[] GetSides(string shapeName){
            Console.Write($"Lütfen {shapeName}'in kenar bilgilerini girin (virgülle ayırın): ");
            string sidesInput = Console.ReadLine();
            string[] sideStrings = sidesInput.Split(',');

            double[] sides = new double[sideStrings.Length];
            for (int i = 0; i < sideStrings.Length; i++)
            {
                if (double.TryParse(sideStrings[i], out double side))
                {
                    sides[i] = side;
                }
                else
                {
                    sides[i] = 0;
                }
            }

            return sides;
        }

        public double GetDimension()
    {
        Console.Write("Hesaplanmak istenen boyutu girin: ");
        if (double.TryParse(Console.ReadLine(), out double dimension))
        {
            return dimension;
        }
        else
        {
            return 0;
        }
    }

    public double Calculate(string shapeName, double[] sides, double dimension)
    {
        double result = 0;

        if (shapeName == "Daire" && sides.Length == 1)
        {
            result = Math.PI * Math.Pow(sides[0], 2); // Dairenin Alanı
        }
        else if (shapeName == "Üçgen" && sides.Length == 3)
        {
            double s = (sides[0] + sides[1] + sides[2]) / 2;
            result = Math.Sqrt(s * (s - sides[0]) * (s - sides[1]) * (s - sides[2])); // Üçgenin Alanı (Heron'un Formülü)
        }
        else if (shapeName == "Kare" && sides.Length == 1)
        {
            result = Math.Pow(sides[0], 2); // Kare Alanı
        }
        else if (shapeName == "Dikdörtgen" && sides.Length == 2)
        {
            result = sides[0] * sides[1]; // Dikdörtgen Alanı
        }

        return result * dimension;
    }

    public string GetResultType(string shapeName)
    {
        switch (shapeName)
        {
            case "Daire":
                return "Dairenin Alanı";
            case "Üçgen":
                return "Üçgenin Alanı";
            case "Kare":
                return "Kare Alanı";
            case "Dikdörtgen":
                return "Dikdörtgen Alanı";
            default:
                return "Sonuç";
        }
    }
    }
}
