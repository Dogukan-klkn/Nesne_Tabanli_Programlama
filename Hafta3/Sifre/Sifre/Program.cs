using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string sifreliMesaj = "şifrelenmiş mesaj";  // Buraya şifreli mesajınızı yazın.
        string cozulmusMesaj = MesajiCoz(sifreliMesaj);
        Console.WriteLine("Çözülmüş Mesaj: " + cozulmusMesaj);
    }

    static string MesajiCoz(string sifreliMesaj)
    {
        List<int> fibonacciSerisi = FibonacciHesapla(sifreliMesaj.Length);
        List<int> asalPozisyonlar = AsalPozisyonlariBul(sifreliMesaj.Length);
        char[] cozulmusMesaj = new char[sifreliMesaj.Length];

        for (int i = 0; i < sifreliMesaj.Length; i++)
        {
            int pozisyon = i + 1;  // 1'den başlayarak pozisyon belirlenir
            int sifreliDeger = sifreliMesaj[i];
            int fibonacciDegeri = fibonacciSerisi[i];

            // Modüler çözümlemeyi geri al
            int asciiDeger;
            if (asalPozisyonlar.Contains(pozisyon))
            {
                asciiDeger = sifreliDeger % 100;
            }
            else
            {
                asciiDeger = sifreliDeger % 256;
            }

            // Fibonacci çarpanını geri alarak orijinal ASCII değerini hesapla
            if (fibonacciDegeri != 0)
            {
                asciiDeger /= fibonacciDegeri;
            }

            // ASCII değerden karaktere dönüştür
            cozulmusMesaj[i] = (char)asciiDeger;
        }

        return new string(cozulmusMesaj);
    }

    // Fibonacci serisini verilen uzunluk kadar hesaplar
    static List<int> FibonacciHesapla(int uzunluk)
    {
        List<int> fibonacci = new List<int> { 1, 1 };
        for (int i = 2; i < uzunluk; i++)
        {
            fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
        }
        return fibonacci;
    }

    // Verilen uzunluk için asal pozisyonları belirler
    static List<int> AsalPozisyonlariBul(int uzunluk)
    {
        List<int> asalPozisyonlar = new List<int>();
        for (int i = 2; i <= uzunluk; i++)
        {
            if (AsalMi(i))
            {
                asalPozisyonlar.Add(i);
            }
        }
        return asalPozisyonlar;
    }

    // Bir sayının asal olup olmadığını kontrol eder
    static bool AsalMi(int sayi)
    {
        if (sayi < 2) return false;
        for (int i = 2; i <= Math.Sqrt(sayi); i++)
        {
            if (sayi % i == 0)
                return false;
        }
        return true;
    }
}
