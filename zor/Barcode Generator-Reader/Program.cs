namespace Barcode_Generator_Reader;
using System;
using System.Drawing;
using System.IO;
using ZXing;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. QR kod üret");
        Console.WriteLine("2. QR kod oku");
        Console.Write("Seçiminizi yapın (1/2): ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            GenerateQRCode();
        }
        else if (choice == "2")
        {
            ReadQRCode();
        }
        else
        {
            Console.WriteLine("Geçersiz seçenek!");
        }
    }

    static void GenerateQRCode()
    {
        Console.Write("QR kod içeriğini girin: ");
        string qrContent = Console.ReadLine();

        BarcodeWriter barcodeWriter = new BarcodeWriter();
        barcodeWriter.Format = BarcodeFormat.QR_CODE;
        barcodeWriter.Options = new QrCodeEncodingOptions
        {
            DisableECI = true,
            CharacterSet = "UTF-8",
            Width = 400,
            Height = 400
        };

        var barcodeBitmap = barcodeWriter.Write(qrContent);

        Console.WriteLine("QR kod üretildi. Kaydediliyor...");
        barcodeBitmap.Save("qr_code.png");

        Console.WriteLine("QR kod dosyaya kaydedildi: qr_code.png");
    }

    static void ReadQRCode()
    {
        Console.Write("QR kod dosyasının adını girin: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            BarcodeReader barcodeReader = new BarcodeReader();
            barcodeReader.AutoRotate = true;
            var barcodeBitmap = (Bitmap)Image.FromFile(fileName);
            var result = barcodeReader.Decode(barcodeBitmap);

            if (result != null)
            {
                Console.WriteLine("QR kod okundu. İçerik: " + result.Text);
            }
            else
            {
                Console.WriteLine("QR kod okunamadı.");
            }
        }
        else
        {
            Console.WriteLine("Belirtilen dosya bulunamadı: " + fileName);
        }
    }

    
}
