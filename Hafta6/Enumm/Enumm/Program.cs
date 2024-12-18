using System;

namespace EnumExample
{
    // 1. Trafik Işığı Durumu Enum'u
    public enum TrafikIsigiDurumu
    {
        Red,   
        Yellow,
        Green   
    }

    // Trafik ışığı durumuna göre ne yapılması gerektiğini belirleyen sınıf
    public class TrafikIshigi
    {
        public static void NeYapilmali(TrafikIsigiDurumu durum)
        {
            switch (durum)
            {
                case TrafikIsigiDurumu.Red:
                    Console.WriteLine("Dur! Kırmızı ışık yanıyor.");
                    break;
                case TrafikIsigiDurumu.Yellow:
                    Console.WriteLine("Dikkat! Sarı ışık yanıyor.");
                    break;
                case TrafikIsigiDurumu.Green:
                    Console.WriteLine("Geç! Yeşil ışık yanıyor.");
                    break;
                default:
                    Console.WriteLine("Bilinmeyen ışık durumu.");
                    break;
            }
        }
    }

    // 2. Çalışan Rolleri Enum'u
    public enum CalisanRol
    {
        Manager,  
        Developer, 
        Designer, 
        Tester     
    }

    // Çalışan rolüne göre maaş hesaplama sınıfı
    public class MaaşHesapla
    {
        public static double Maaş(CalisanRol rol)
        {
            switch (rol)
            {
                case CalisanRol.Manager:
                    return 8000.00; // Yöneticinin maaşı
                case CalisanRol.Developer:
                    return 6000.00; // Geliştiricinin maaşı
                case CalisanRol.Designer:
                    return 5000.00; // Tasarımcının maaşı
                case CalisanRol.Tester:
                    return 4000.00; // Test Uzmanının maaşı
                default:
                    return 0.00; // Geçersiz rol
            }
        }
    }

    // 3. Hava Durumu Tahmini Enum'u
    public enum HavaDurumu
    {
        Sunny,  
        Rainy,  
        Cloudy,
        Stormy  
    }

    // Hava durumuna göre tavsiyede bulunan sınıf
    public class HavaDurumuTavsiyesi
    {
        public static void TavsiyeVer(HavaDurumu durum)
        {
            switch (durum)
            {
                case HavaDurumu.Sunny:
                    Console.WriteLine("Bugün güneşli. Dışarıda zaman geçirmek için harika bir gün!");
                    break;
                case HavaDurumu.Rainy:
                    Console.WriteLine("Yağmurlu bir gün. Şemsiye almayı unutma!");
                    break;
                case HavaDurumu.Cloudy:
                    Console.WriteLine("Bulutlu bir gün. Yine de dışarıda vakit geçirebilirsin.");
                    break;
                case HavaDurumu.Stormy:
                    Console.WriteLine("Fırtınalı bir hava. Evde kalmak en iyisi.");
                    break;
                default:
                    Console.WriteLine("Bilinmeyen hava durumu.");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Trafik ışığı durumuna göre ne yapılması gerektiği
            TrafikIshigi.NeYapilmali(TrafikIsigiDurumu.Green);
            TrafikIshigi.NeYapilmali(TrafikIsigiDurumu.Red);

            // Çalışan rolüne göre maaş hesaplama
            Console.WriteLine($"Yönetici maaşı: {MaaşHesapla.Maaş(CalisanRol.Manager)}");
            Console.WriteLine($"Geliştirici maaşı: {MaaşHesapla.Maaş(CalisanRol.Developer)}");

            // Hava durumu tavsiyesi
            HavaDurumuTavsiyesi.TavsiyeVer(HavaDurumu.Sunny);
            HavaDurumuTavsiyesi.TavsiyeVer(HavaDurumu.Rainy);
        }
    }
}
