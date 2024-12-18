using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaYonetim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap türünü seçiniz (1: Vadesiz Hesap, 2: Vadeli Hesap):");
            int secim = int.Parse(Console.ReadLine());

            Hesap hesap;

            if (secim == 1)
            {
                hesap = new VadesizHesap
                {
                    HesapNo = "123456",
                    HesapSahibi = "Ahmet Yılmaz",
                    EkHesapLimiti = 500
                };
            }
            else
            {
                hesap = new VadeliHesap
                {
                    HesapNo = "789012",
                    HesapSahibi = "Fatma Kaya",
                    VadeSuresi = 30,
                    FaizOrani = 0.15m,
                    VadeBitisTarihi = DateTime.Now.AddDays(30)
                };
            }

            hesap.ParaYatir(1000);
            hesap.BilgiYazdir();

            Console.WriteLine("Çekmek istediğiniz miktarı giriniz:");
            decimal miktar = decimal.Parse(Console.ReadLine());

            hesap.ParaCek(miktar);
            hesap.BilgiYazdir();
            Console.ReadLine();
        }
    }

    class Hesap
    {
        public string HesapNo { get; set; }
        public string HesapSahibi { get; set; }
        public decimal Bakiye { get; protected set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar:C} yatırıldı. Güncel bakiye: {Bakiye:C}");
        }

        public virtual void ParaCek(decimal miktar)
        {
            if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            else
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar:C} çekildi. Güncel bakiye: {Bakiye:C}");
            }
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap No: {HesapNo}\nHesap Sahibi: {HesapSahibi}\nBakiye: {Bakiye:C}");
        }
    }

    class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (miktar > Bakiye + EkHesapLimiti)
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti.");
            }
            else
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar:C} çekildi. Güncel bakiye: {Bakiye:C}");
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti:C}");
        }
    }

    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; } // Gün cinsinden vade süresi
        public decimal FaizOrani { get; set; } // Yıllık faiz oranı
        public DateTime VadeBitisTarihi { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (DateTime.Now < VadeBitisTarihi)
            {
                Console.WriteLine("Vade bitmeden para çekemezsiniz.");
            }
            else
            {
                base.ParaCek(miktar);
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Vade Süresi: {VadeSuresi} gün\nFaiz Oranı: {FaizOrani:P}\nVade Bitiş Tarihi: {VadeBitisTarihi:dd/MM/yyyy}");
        }
    }
}
