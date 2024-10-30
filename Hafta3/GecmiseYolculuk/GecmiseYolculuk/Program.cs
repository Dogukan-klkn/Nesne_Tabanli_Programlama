using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Geçmişe Yolculuk Zamanlayıcısı: Geçerli Tarihler");
        List<string> uygunTarihler = TarihleriBul(2000, 3000);

        foreach (string tarih in uygunTarihler)
        {
            Console.WriteLine(tarih);
        }
    }

    // Tüm uygun tarihleri bulmak için ana algoritma
    static List<string> TarihleriBul(int baslangicYil, int bitisYil)
    {
        List<string> uygunTarihler = new List<string>();
        DateTime simdikiZaman = DateTime.Now;

        for (int yil = baslangicYil; yil <= bitisYil; yil++)
        {
            if (!YilKosulunuSaglar(yil)) continue;

            for (int ay = 1; ay <= 12; ay++)
            {
                if (!AyKosulunuSaglar(ay)) continue;

                int gunSayisi = DateTime.DaysInMonth(yil, ay);

                for (int gun = 1; gun <= gunSayisi; gun++)
                {
                    if (!GunAsalMi(gun)) continue;

                    DateTime tarih = new DateTime(yil, ay, gun);
                    if (tarih > simdikiZaman)
                    {
                        uygunTarihler.Add($"{gun:D2}/{ay:D2}/{yil}");
                    }
                }
            }
        }

        return uygunTarihler;
    }

    // Günün asal olup olmadığını kontrol et
    static bool GunAsalMi(int gun)
    {
        if (gun < 2) return false;
        for (int i = 2; i <= Math.Sqrt(gun); i++)
        {
            if (gun % i == 0) return false;
        }
        return true;
    }

    // Ayın basamak toplamının çift olup olmadığını kontrol et
    static bool AyKosulunuSaglar(int ay)
    {
        int toplam = 0;
        while (ay > 0)
        {
            toplam += ay % 10;
            ay /= 10;
        }
        return toplam % 2 == 0;
    }

    // Yılın rakamlar toplamı, yılın dörtte birinden küçük olup olmadığını kontrol et
    static bool YilKosulunuSaglar(int yil)
    {
        int toplam = 0, tempYil = yil;
        while (tempYil > 0)
        {
            toplam += tempYil % 10;
            tempYil /= 10;
        }
        return toplam < yil / 4;
    }
}
