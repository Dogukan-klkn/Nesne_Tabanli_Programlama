using System;

class Kitaplik
{
    private string[] kitaplar;

    public Kitaplik(int kapasite)
    {
        kitaplar = new string[kapasite];
    }

    // İndeksleyici ile kitap erişimi sağlanır
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= kitaplar.Length)
                throw new ArgumentOutOfRangeException("Geçersiz indeks.");
            return kitaplar[index];
        }
        set
        {
            if (index < 0 || index >= kitaplar.Length)
                throw new ArgumentOutOfRangeException("Geçersiz indeks.");
            kitaplar[index] = value;
        }
    }
}

class OgrenciNotSistemi
{
    private string[] dersler;
    private int[] notlar;

    public OgrenciNotSistemi(int kapasite)
    {
        dersler = new string[kapasite];
        notlar = new int[kapasite];
    }

    // İndeksleyici ile ders notlarına erişim sağlanır
    public int this[string dersAdi]
    {
        get
        {
            int index = Array.IndexOf(dersler, dersAdi);
            if (index >= 0)
                return notlar[index];
            else
                throw new KeyNotFoundException("Ders bulunamadı.");
        }
        set
        {
            int index = Array.IndexOf(dersler, dersAdi);
            if (index >= 0)
                notlar[index] = value;
            else
                throw new KeyNotFoundException("Ders bulunamadı.");
        }
    }

    public void DersEkle(string dersAdi, int notu)
    {
        int index = Array.IndexOf(dersler, null); // boş alanı bul
        if (index >= 0)
        {
            dersler[index] = dersAdi;
            notlar[index] = notu;
        }
        else
        {
            throw new InvalidOperationException("Ders eklemek için boş alan yok.");
        }
    }
}

class SatrancTahtasi
{
    private string[,] tahtadakiKareler = new string[8, 8];

    // Satranç tahtasındaki kareye taş koyma ya da taşı öğrenme
    public string this[int satir, int sutun]
    {
        get
        {
            if (satir < 0 || satir >= 8 || sutun < 0 || sutun >= 8)
                throw new ArgumentOutOfRangeException("Geçersiz kare.");
            return tahtadakiKareler[satir, sutun] ?? "Boş";
        }
        set
        {
            if (satir < 0 || satir >= 8 || sutun < 0 || sutun >= 8)
                throw new ArgumentOutOfRangeException("Geçersiz kare.");
            tahtadakiKareler[satir, sutun] = value;
        }
    }
}

class Otopark
{
    private string[,] parkYerleri;

    public Otopark(int katSayisi, int parkYeriSayisi)
    {
        parkYerleri = new string[katSayisi, parkYeriSayisi];
    }

    // Otopark katı ve park yerine göre araç durumu
    public string this[int kat, int parkYeri]
    {
        get
        {
            if (kat < 0 || kat >= parkYerleri.GetLength(0) || parkYeri < 0 || parkYeri >= parkYerleri.GetLength(1))
                throw new ArgumentOutOfRangeException("Geçersiz park yeri.");
            return string.IsNullOrEmpty(parkYerleri[kat, parkYeri]) ? "Empty" : parkYerleri[kat, parkYeri];
        }
        set
        {
            if (kat < 0 || kat >= parkYerleri.GetLength(0) || parkYeri < 0 || parkYeri >= parkYerleri.GetLength(1))
                throw new ArgumentOutOfRangeException("Geçersiz park yeri.");
            parkYerleri[kat, parkYeri] = value;
        }
    }
}

class Program
{
    static void Main()
    {
        // 1. Kitaplık Yönetim Sistemi
        Kitaplik kitaplik = new Kitaplik(5);
        kitaplik[0] = "Harry Potter";
        kitaplik[1] = "Yüzüklerin Efendisi";

        Console.WriteLine("Kitap 1: " + kitaplik[0]);
        Console.WriteLine("Kitap 2: " + kitaplik[1]);

        // Geçersiz indeks denemesi
        try
        {
            Console.WriteLine(kitaplik[5]);  // 5. indeks geçersiz (0-4 arası)
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);  // Hata mesajı göster
        }

        // 2. Öğrenci Not Sistemi
        OgrenciNotSistemi notSistemi = new OgrenciNotSistemi(3);
        notSistemi.DersEkle("Matematik", 85);
        notSistemi.DersEkle("Fizik", 90);

        Console.WriteLine("Matematik Notu: " + notSistemi["Matematik"]);
        Console.WriteLine("Fizik Notu: " + notSistemi["Fizik"]);

        // Geçersiz ders denemesi
        try
        {
            Console.WriteLine(notSistemi["Kimya"]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);  // Hata mesajı göster
        }

        // 3. Satranç Tahtası Durumu
        SatrancTahtasi tahtasi = new SatrancTahtasi();
        tahtasi[0, 0] = "Beyaz Kral";
        tahtasi[7, 7] = "Siyah Kraliçe";

        Console.WriteLine("0,0 Karede: " + tahtasi[0, 0]);
        Console.WriteLine("7,7 Karede: " + tahtasi[7, 7]);

        // Geçersiz kare denemesi
        try
        {
            Console.WriteLine(tahtasi[8, 8]);  // Geçersiz kare
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);  // Hata mesajı göster
        }

        // 4. Otopark Sistemi
        Otopark otopark = new Otopark(3, 5); // 3 kat, her kat 5 park yeri
        otopark[0, 0] = "AB123CD";
        otopark[1, 2] = "EF456GH";

        Console.WriteLine("Kat 0, Park Yeri 0: " + otopark[0, 0]);
        Console.WriteLine("Kat 1, Park Yeri 2: " + otopark[1, 2]);

        // Geçersiz park yeri denemesi
        try
        {
            Console.WriteLine(otopark[3, 5]);  // Geçersiz park yeri
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);  // Hata mesajı göster
        }
    }
}
