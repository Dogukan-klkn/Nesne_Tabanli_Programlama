using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÜrünSiparis
{


    public class Urun
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }

        public string UrunBilgisi()
        {
            return $"Ürün Adı: {Ad}, Fiyat: {Fiyat} TL";
        }
    }

    public class Siparis
    {
        public DateTime Tarih { get; set; }
        public decimal Toplam { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
