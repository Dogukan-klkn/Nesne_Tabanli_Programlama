using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            // Banka Hesabı Sınıfı örneği
            BankaHesabi hesap = new BankaHesabi("123456", 1000);
            hesap.ParaYatir(500);
            hesap.ParaCek(200);
            Console.WriteLine($"Bakiye: {hesap.GetBakiye()}");

            // Ürün Sınıfı örneği
            Urun urun = new Urun("Laptop", 5000);
            urun.Indirim = 10;
            Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat()}");

            // Araç Kiralama Sınıfı örneği
            KiralikArac arac = new KiralikArac("34XYZ123", 150);
            arac.AraciKirala();
            arac.AraciTeslimEt();

            // Adres Defteri Sınıfı örneği
            Kisi kisi = new Kisi("Ahmet", "Yılmaz", "0555 123 4567");
            Console.WriteLine(kisi.KisiBilgisi());

            // Kütüphane Sınıfı örneği
            Kutuphane kutuphane = new Kutuphane();
            Kitap kitap = new Kitap("C# Programlama", "Ali Demir");
            kutuphane.KitapEkle(kitap);
            kutuphane.KitaplariListele();
            Console.ReadKey();
        }
    }
    //Soru 1 Banka Sınıfı
    class BankaHesabi
    {
        public string HesapNumarasi { get; private set; }
        private decimal Bakiye;

        public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = ilkBakiye;
        }

        public void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
                Bakiye += miktar;
            else
                Console.WriteLine("Geçerli bir miktar giriniz.");
        }

        public void ParaCek(decimal miktar)
        {
            if (miktar > 0 && miktar <= Bakiye)
                Bakiye -= miktar;
            else
                Console.WriteLine("Yetersiz bakiye veya geçersiz miktar.");
        }

        public decimal GetBakiye()
        {
            return Bakiye;
        }
    }

    // Soru 2: Ürün Sınıfı
    class Urun
    {
        public string Ad { get; private set; }
        public decimal Fiyat { get; private set; }
        private decimal indirim;

        public decimal Indirim
        {
            get { return indirim; }
            set
            {
                if (value >= 0 && value <= 50)
                    indirim = value;
                else
                    Console.WriteLine("İndirim oranı 0 ile 50 arasında olmalıdır.");
            }
        }

        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public decimal IndirimliFiyat()
        {
            return Fiyat * (1 - Indirim / 100);
        }
    }

    // Soru 3: Araç Kiralama Sınıfı
    class KiralikArac
    {
        public string Plaka { get; private set; }
        public decimal GunlukUcret { get; private set; }
        public bool MusaitMi { get; private set; }

        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
            MusaitMi = true;
        }

        public void AraciKirala()
        {
            if (MusaitMi)
                MusaitMi = false;
            else
                Console.WriteLine("Araç zaten kirada.");
        }

        public void AraciTeslimEt()
        {
            if (!MusaitMi)
                MusaitMi = true;
            else
                Console.WriteLine("Araç zaten teslim edilmiş durumda.");
        }
    }

    // Soru 4: Adres Defteri Sınıfı
    class Kisi
    {
        public string Ad { get; private set; }
        public string Soyad { get; private set; }
        public string TelefonNumarasi { get; private set; }

        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        public string KisiBilgisi()
        {
            return $"{Ad} {Soyad}, Tel: {TelefonNumarasi}";
        }
    }

    // Soru 5: Kütüphane Sınıfı
    class Kutuphane
    {
        public List<Kitap> Kitaplar { get; private set; }

        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap yeniKitap)
        {
            Kitaplar.Add(yeniKitap);
            Console.WriteLine($"{yeniKitap.Ad} kütüphaneye eklendi.");
        }

        public void KitaplariListele()
        {
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"{kitap.Ad}, Yazar: {kitap.Yazar}");
            }
        }
    }

    class Kitap
    {
        public string Ad { get; private set; }
        public string Yazar { get; private set; }

        public Kitap(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }
    }
}
