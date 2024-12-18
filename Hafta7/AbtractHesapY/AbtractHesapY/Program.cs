using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbtractHesapY
{


    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; }
        string HesapOzeti();
    }
    public abstract class Hesap : IBankaHesabi
    {
        public int HesapNo { get; protected set; }
        public decimal Bakiye { get; protected set; }
        public DateTime HesapAcilisTarihi { get; private set; }

        public Hesap(int hesapNo, decimal baslangicBakiyesi)
        {
            HesapNo = hesapNo;
            Bakiye = baslangicBakiyesi;
            HesapAcilisTarihi = DateTime.Now;
        }

        public abstract void ParaYatir(decimal miktar);
        public abstract void ParaCek(decimal miktar);

        public virtual string HesapOzeti()
        {
            return $"Hesap No: {HesapNo}\nBakiye: {Bakiye:C}\nAçılış Tarihi: {HesapAcilisTarihi:dd/MM/yyyy}";
        }
    }

    public class BirikimHesabi : Hesap
    {
        public decimal FaizOrani { get; private set; }

        public BirikimHesabi(int hesapNo, decimal baslangicBakiyesi, decimal faizOrani) : base(hesapNo, baslangicBakiyesi)
        {
            FaizOrani = faizOrani;
        }

        public override void ParaYatir(decimal miktar)
        {
            if (miktar <= 0)
                throw new ArgumentException("Yatırılacak miktar pozitif olmalıdır.");

            decimal faiz = miktar * FaizOrani;
            Bakiye += miktar + faiz;
        }

        public override void ParaCek(decimal miktar)
        {
            if (miktar <= 0 || miktar > Bakiye)
                throw new ArgumentException("Geçersiz miktar.");

            Bakiye -= miktar;
        }

        public override string HesapOzeti()
        {
            return base.HesapOzeti() + $"\nFaiz Oranı: {FaizOrani:P}";
        }
    }
    public class VadesizHesap : Hesap
    {
        private const decimal IslemUcreti = 2.00m;

        public VadesizHesap(int hesapNo, decimal baslangicBakiyesi) : base(hesapNo, baslangicBakiyesi)
        {
        }

        public override void ParaYatir(decimal miktar)
        {
            if (miktar <= 0)
                throw new ArgumentException("Yatırılacak miktar pozitif olmalıdır.");

            Bakiye += miktar;
        }

        public override void ParaCek(decimal miktar)
        {
            decimal toplamMiktar = miktar + IslemUcreti;

            if (miktar <= 0 || toplamMiktar > Bakiye)
                throw new ArgumentException("Geçersiz miktar ya da yetersiz bakiye.");

            Bakiye -= toplamMiktar;
        }

        public override string HesapOzeti()
        {
            return base.HesapOzeti() + $"\nİşlem Ücreti: {IslemUcreti:C}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Hesap> hesaplar = new List<Hesap>();

            // BirikimHesabi oluşturma
            BirikimHesabi birikimHesabi = new BirikimHesabi(1001, 5000, 0.03m);
            birikimHesabi.ParaYatir(1000);
            birikimHesabi.ParaCek(200);
            hesaplar.Add(birikimHesabi);

            // VadesizHesap oluşturma
            VadesizHesap vadesizHesap = new VadesizHesap(2001, 3000);
            vadesizHesap.ParaYatir(500);
            vadesizHesap.ParaCek(700);
            hesaplar.Add(vadesizHesap);

            // Hesap özetlerini yazdırma
            foreach (var hesap in hesaplar)
            {
                Console.WriteLine(hesap.HesapOzeti());
                Console.WriteLine("--------------------------");
            }

            Console.ReadLine();
        }
    }
}
