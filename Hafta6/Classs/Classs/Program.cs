using System;

class Program
{
    // 1. Matematiksel İşlemler (Toplama)
    // İki tam sayıyı toplar
    public static int Topla(int a, int b)
    {
        return a + b;
    }

    // Üç tam sayıyı toplar
    public static int Topla(int a, int b, int c)
    {
        return a + b + c;
    }

    // Bir dizi tam sayıyı toplar
    public static int Topla(int[] sayilar)
    {
        int toplam = 0;
        foreach (var sayi in sayilar)
        {
            toplam += sayi;
        }
        return toplam;
    }

    // 2. Farklı Şekillerin Alan Hesaplama
    // Karenin alanını hesaplar (kenar uzunluğu verilerek)
    public static double AlanHesapla(double kenar)
    {
        return kenar * kenar;
    }

    // Dikdörtgenin alanını hesaplar (iki kenar uzunluğu verilerek)
    public static double AlanHesapla(double uzunluk, double genislik)
    {
        return uzunluk * genislik;
    }

    // Dairenin alanını hesaplar (yarıçap verilerek)
    public static double AlanHesapla(double yaricap, string sekilTuru)
    {
        if (sekilTuru.ToLower() == "daire")
        {
            return Math.PI * yaricap * yaricap;
        }
        else
        {
            throw new ArgumentException("Geçersiz şekil türü");
        }
    }

    // 3. Zaman Farkını Hesaplama
    // İki tarih arasındaki farkı gün cinsinden döndürür
    public static int ZamanFarki(DateTime tarih1, DateTime tarih2)
    {
        return (tarih2 - tarih1).Days;
    }

    // İki tarih arasındaki farkı saat cinsinden döndürür
    public static int ZamanFarki(DateTime tarih1, DateTime tarih2, string format)
    {
        return (int)(tarih2 - tarih1).TotalHours;
    }

    // İki tarih arasındaki farkı yıl, ay ve gün cinsinden döndürür
    public static string ZamanFarki(DateTime tarih1, DateTime tarih2, bool detayli)
    {
        int yilFarki = tarih2.Year - tarih1.Year;
        int ayFarki = tarih2.Month - tarih1.Month;
        int gunFarki = tarih2.Day - tarih1.Day;

        if (gunFarki < 0)
        {
            ayFarki--;
            gunFarki += DateTime.DaysInMonth(tarih2.Year, tarih2.Month);
        }
        if (ayFarki < 0)
        {
            yilFarki--;
            ayFarki += 12;
        }

        return $"{yilFarki} yıl, {ayFarki} ay, {gunFarki} gün";
    }

    static void Main()
    {
        // 1. Matematiksel İşlemler
        Console.WriteLine("Toplam (iki sayı): " + Topla(5, 3));
        Console.WriteLine("Toplam (üç sayı): " + Topla(5, 3, 7));
        Console.WriteLine("Toplam (dizi): " + Topla(new int[] { 1, 2, 3, 4, 5 }));

        // 2. Şekil Alan Hesaplama
        Console.WriteLine("Karenin Alanı: " + AlanHesapla(5));
        Console.WriteLine("Dikdörtgenin Alanı: " + AlanHesapla(5, 10));
        Console.WriteLine("Dairenin Alanı: " + AlanHesapla(7));

        // 3. Zaman Farkı Hesaplama
        DateTime tarih1 = new DateTime(2023, 1, 1);
        DateTime tarih2 = new DateTime(2024, 1, 1);

        Console.WriteLine("Zaman Farkı (gün): " + ZamanFarki(tarih1, tarih2));
        Console.WriteLine("Zaman Farkı (saat): " + ZamanFarki(tarih1, tarih2, "saat"));
        Console.WriteLine("Zaman Farkı (yıl, ay, gün): " + ZamanFarki(tarih1, tarih2, true));
    }
}
