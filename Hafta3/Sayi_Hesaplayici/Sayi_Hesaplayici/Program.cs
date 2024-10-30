using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> sayilar = new List<int>();
        int giris;

        // Kullanıcıdan pozitif tam sayılar al
        Console.WriteLine("Pozitif tam sayıları girin (Bitirmek için 0 girin):");
        do
        {
            giris = int.Parse(Console.ReadLine());
            if (giris > 0)
                sayilar.Add(giris);
        } while (giris != 0);

        // Sayı yoksa çıkış yap
        if (sayilar.Count == 0)
        {
            Console.WriteLine("Hiç sayı girilmedi.");
            return;
        }

        // Ortalamayı hesapla
        double ortalama = sayilar.Average();

        // Medyanı hesapla
        sayilar.Sort();
        double medyan;
        int ortadaki = sayilar.Count / 2;

        if (sayilar.Count % 2 == 0)
            medyan = (sayilar[ortadaki - 1] + sayilar[ortadaki]) / 2.0;
        else
            medyan = sayilar[ortadaki];

        // Sonuçları ekrana yazdır
        Console.WriteLine($"Girilen sayıların ortalaması: {ortalama}");
        Console.WriteLine($"Girilen sayıların medyanı: {medyan}");
    }
}
