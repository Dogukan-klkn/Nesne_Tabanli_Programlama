using System;

public struct Zaman
{
    public int Hour { get; set; }
    public int Minute { get; set; }

    // Yapıcı metot: Saat ve dakika girildiğinde geçersizse 0 yapılır
    public Zaman(int hour, int minute)
    {
        Hour = (hour >= 0 && hour < 24) ? hour : 0;  // Geçerli saat aralığı 0-23
        Minute = (minute >= 0 && minute < 60) ? minute : 0;  // Geçerli dakika aralığı 0-59
    }

    // Zamanın toplam dakika değeri
    public int ToplamDakika()
    {
        return Hour * 60 + Minute;
    }

    // İki zaman arasındaki farkı dakika cinsinden hesaplama
    public static int Fark(Zaman zaman1, Zaman zaman2)
    {
        int farkDakika = Math.Abs(zaman1.ToplamDakika() - zaman2.ToplamDakika());
        return farkDakika;
    }
}

public struct KarmaşikSayi
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    // Yapıcı metot
    public KarmaşikSayi(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Toplama işlemi
    public static KarmaşikSayi operator +(KarmaşikSayi sayi1, KarmaşikSayi sayi2)
    {
        return new KarmaşikSayi(sayi1.Real + sayi2.Real, sayi1.Imaginary + sayi2.Imaginary);
    }

    // Çıkarma işlemi
    public static KarmaşikSayi operator -(KarmaşikSayi sayi1, KarmaşikSayi sayi2)
    {
        return new KarmaşikSayi(sayi1.Real - sayi2.Real, sayi1.Imaginary - sayi2.Imaginary);
    }

    // Karmaşık sayıyı "a + bi" formatında yazdırma
    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

public struct GPSKonum
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    // Yapıcı metot
    public GPSKonum(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    // Haversine Formülü ile iki GPS noktası arasındaki mesafe
    public static double Mesafe(GPSKonum konum1, GPSKonum konum2)
    {
        double R = 6371; // Dünya'nın yarıçapı (km)
        double lat1Rad = ToRadians(konum1.Latitude);
        double lon1Rad = ToRadians(konum1.Longitude);
        double lat2Rad = ToRadians(konum2.Latitude);
        double lon2Rad = ToRadians(konum2.Longitude);

        double dlat = lat2Rad - lat1Rad;
        double dlon = lon2Rad - lon1Rad;

        double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Sin(dlon / 2) * Math.Sin(dlon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return R * c; // km cinsinden mesafe
    }

    // Dereceyi radiana dönüştürme metodu
    private static double ToRadians(double derece)
    {
        return derece * (Math.PI / 180);
    }
}

class Program
{
    static void Main()
    {
        // Zaman İşlemleri
        Zaman zaman1 = new Zaman(10, 30);
        Zaman zaman2 = new Zaman(12, 45);
        Console.WriteLine($"Toplam Dakika (Zaman 1): {zaman1.ToplamDakika()}");
        Console.WriteLine($"Toplam Dakika (Zaman 2): {zaman2.ToplamDakika()}");
        Console.WriteLine($"Zamanlar Arası Fark: {Zaman.Fark(zaman1, zaman2)} dakika");

        // Karmaşık Sayılar
        KarmaşikSayi sayi1 = new KarmaşikSayi(3, 4);
        KarmaşikSayi sayi2 = new KarmaşikSayi(1, 2);
        KarmaşikSayi toplam = sayi1 + sayi2;
        KarmaşikSayi fark = sayi1 - sayi2;
        Console.WriteLine($"Sayı 1: {sayi1}");
        Console.WriteLine($"Sayı 2: {sayi2}");
        Console.WriteLine($"Toplama Sonucu: {toplam}");
        Console.WriteLine($"Çıkarma Sonucu: {fark}");

        // GPS Konum Mesafesi
        GPSKonum konum1 = new GPSKonum(41.0082, 28.9784); // İstanbul
        GPSKonum konum2 = new GPSKonum(48.8566, 2.3522); // Paris
        double mesafe = GPSKonum.Mesafe(konum1, konum2);
        Console.WriteLine($"İstanbul ile Paris arasındaki mesafe: {mesafe} km");
    }
}
