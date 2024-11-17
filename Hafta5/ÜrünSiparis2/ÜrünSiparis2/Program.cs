using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÜrünSiparis2
{

    public class Musteri
    {
        public string Ad { get; set; }
        public string Telefon { get; set; }

        public void SiparisVer(Siparis siparis)
        {
            // Sipariş oluşturma işlemleri
            System.Console.WriteLine($"Müşteri {Ad} yeni bir sipariş verdi. Sipariş Tarihi: {siparis.Tarih}, Durumu: {siparis.Durum}");
        }
    }

    public class Siparis
    {
        public DateTime Tarih { get; set; }
        public string Durum { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
        }
    }
}
