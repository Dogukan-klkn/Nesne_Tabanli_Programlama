using System;
using System.Collections.Generic;

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
            if (giris != 0)
                sayilar.Add(giris);
        } while (giris != 0);

        // Sayılar yoksa çıkış yap
        if (sayilar.Count == 0)
        {
            Console.WriteLine("Hiç sayı girilmedi.");
            return;
        }

        // Sayıları sırala
        sayilar.Sort();

        // Ardışık grupları tespit et ve yazdır
        Console.WriteLine("Ardışık sayı grupları:");
        for (int i = 0; i < sayilar.Count; i++)
        {
            int baslangic = sayilar[i];

            // Ardışık grubu bulun
            while (i < sayilar.Count - 1 && sayilar[i + 1] == sayilar[i] + 1)
                i++;

            int bitis = sayilar[i];

            // Tek sayı veya ardışık grup olup olmadığını kontrol et
            if (baslangic == bitis)
                Console.WriteLine($"{baslangic}");
            else
                Console.WriteLine($"{baslangic}-{bitis}");
        }
    }
}
