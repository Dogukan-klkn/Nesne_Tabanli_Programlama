using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YazarKitap
{
    

    public class Kitap
    {
        public string Baslik { get; set; }
        public string ISBN { get; set; }

        // Yapıcı metot
        public Kitap(string baslik, string isbn)
        {
            Baslik = baslik;
            ISBN = isbn;
        }
    }

    public class Yazar
    {
        public string Ad { get; set; }
        public string Ulke { get; set; }
        private List<Kitap> Kitaplar { get; set; }

        // Yapıcı metot
        public Yazar(string ad, string ulke)
        {
            Ad = ad;
            Ulke = ulke;
            Kitaplar = new List<Kitap>();
        }

        // Kitap ekleme metodu
        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }

        // Kitapları listeleme metodu
        public List<Kitap> KitaplariGetir()
        {
            return Kitaplar;
        }
    }






    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
