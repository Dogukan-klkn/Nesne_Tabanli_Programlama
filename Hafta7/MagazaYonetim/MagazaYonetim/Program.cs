using System;
using System.Collections.Generic;

// 1. Soyut Urun sınıfı
abstract class Urun
{
    public string Ad { get; set; }
    public double Fiyat { get; set; }

    // Soyut metot
    public abstract double HesaplaOdeme();

    // Ortak bir bilgi yazdırma metodu
    public virtual void BilgiYazdir()
    {
        Console.WriteLine($"Ürün Adı: {Ad}");
        Console.WriteLine($"Fiyat: {Fiyat:C}");
    }
}

// 2. Kitap sınıfı
class Kitap : Urun
{
    public string Yazar { get; set; }
    public override double HesaplaOdeme()
    {
        // %10 vergi ekleniyor
        return Fiyat * 1.10;
    }

    public override void BilgiYazdir()
    {
        base.BilgiYazdir();
        Console.WriteLine($"Yazar: {Yazar}");
        Console.WriteLine($"Ödenecek Tutar: {HesaplaOdeme():C}");
    }
}

// 2. Elektronik sınıfı
class Elektronik : Urun
{
    public string Marka { get; set; }
    public override double HesaplaOdeme()
    {
        // %25 vergi ekleniyor
        return Fiyat * 1.25;
    }

    public override void BilgiYazdir()
    {
        base.BilgiYazdir();
        Console.WriteLine($"Marka: {Marka}");
        Console.WriteLine($"Ödenecek Tutar: {HesaplaOdeme():C}");
    }
}

// 4. Ana program
class Program
{
    static void Main(string[] args)
    {
        // Ürün koleksiyonu oluşturuluyor
        List<Urun> urunler = new List<Urun>();

        // Kitap örneği ekleniyor
        urunler.Add(new Kitap
        {
            Ad = "Bir Bilim Adamının Romanı",
            Fiyat = 50,
            Yazar = "Oğuz Atay"
        });

        // Elektronik örneği ekleniyor
        urunler.Add(new Elektronik
        {
            Ad = "Kulaklık",
            Fiyat = 200,
            Marka = "Sony"
        });

        // Ürün bilgileri ekrana yazdırılıyor
        foreach (var urun in urunler)
        {
            urun.BilgiYazdir();
            Console.WriteLine("-------------------");
        }
    }
}
