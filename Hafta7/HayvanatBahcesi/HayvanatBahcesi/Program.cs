using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanatBahcesi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hayvan türünü seçin. MEMELİ=1  , KUŞ=2");
            int secim = Convert.ToInt32(Console.ReadLine());

            Hayvan hayvan;
            if (secim == 1)
            {
                hayvan = new Memeli();
                Console.WriteLine("Ad:");
                hayvan.ad = Console.ReadLine();
                Console.WriteLine("Tür:");
                hayvan.tür = Console.ReadLine();
                Console.WriteLine("Yaş:");
                hayvan.yas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Tüy Rengi:");
                ((Memeli)hayvan).tüyRengi = Console.ReadLine();

            }
            else if(secim == 2)
            {
                hayvan = new Kus();
                Console.WriteLine("Ad:");
                hayvan.ad = Console.ReadLine();
                Console.WriteLine("Tür:");
                hayvan.tür = Console.ReadLine();
                Console.WriteLine("Yaş:");
                hayvan.yas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Kanat Genişliği:");
                ((Kus)hayvan).kanatGenisligi = Convert.ToInt32(Console.ReadLine());



            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Program sonlandırılıyor.");
                return;
            }
            Console.WriteLine("Hayan Bilgileri:");
            hayvan.SesCikar();
            Console.ReadKey();
        }
    }

    class Hayvan
    {
        public String ad { get; set; }
        public String tür { get; set; }
        public int yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine($"Ad: {ad} \nTür {tür} \nYaş: {yas}");

        }

    }

    class Memeli : Hayvan
    {
        public String tüyRengi { get; set; }

        public override void SesCikar()
        {
            base.SesCikar();
            Console.WriteLine($"Tüy Rengi: {tüyRengi} ");
            Console.WriteLine("MEMELİ HAYVAN SES ÇIKARIYOR...");
        }


    }
    class Kus : Hayvan
    {
        public double kanatGenisligi { get; set; }

        public override void SesCikar()
        {
            base.SesCikar();
            Console.WriteLine($"Kanat Genişliği: {kanatGenisligi} cm");
            Console.WriteLine("KUŞ SES ÇIKARIYOR......");
        }


    }
}
