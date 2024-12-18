using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yonetim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan türünü seçiniz: Yazılımcı: 1  Muhasebeci: 2");
            int secim =Convert.ToInt32(Console.ReadLine());
            Calisan calisan;

            if(secim == 1)
            {
                calisan = new Yazilimci();
                Console.WriteLine("Ad:");
                calisan.ad = Console.ReadLine();
                Console.WriteLine("Soyad:");
                calisan.soyad = Console.ReadLine();
                Console.WriteLine("Maaş:");
                calisan.maas = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Pozisyon:");
                calisan.pozisyon = Console.ReadLine();
                Console.WriteLine("Yazılım dili:");
                ((Yazilimci)calisan).yazilimdili = Console.ReadLine();
            }
            else if(secim == 2)
            {
                calisan = new  Muhasebeci();
                Console.WriteLine("Ad:");
                calisan.ad = Console.ReadLine();
                Console.WriteLine("Soyad:");
                calisan.soyad = Console.ReadLine();
                Console.WriteLine("Maaş:");
                calisan.maas = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Pozisyon:");
                calisan.pozisyon = Console.ReadLine();
                Console.WriteLine("Yazılım dili:");
                ((Muhasebeci)calisan).muhasebeyazılımdili = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim, program sonlandırılıyor.");
                return;
            }

            Console.WriteLine("Çalışan bilgileri: \n");
            calisan.BilgiYazdir();
            Console.ReadKey();

        }
    }

    public class Calisan
    {
        public String ad { get; set; }
        public String soyad { get; set; }
        public double maas { get; set; }
        public String pozisyon { get; set; }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {ad} \nSoyad: {soyad} \nMaaş:{maas} TL\nPozisyon: {pozisyon}");
        }

    }

    public class Yazilimci : Calisan
    {
        public String yazilimdili { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazılım dili bilgisi: {yazilimdili}");
        }

    }
    public class Muhasebeci : Calisan
    {
        public String muhasebeyazılımdili { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Muhasebeci yazılım dili : {muhasebeyazılımdili}");
        }

    }
}
