using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorHasta
{

    public class Doktor
    {
        public string Ad { get; set; }
        public string Brans { get; set; }
        public List<Hasta> Hastalar { get; set; }

        public Doktor()
        {
            Hastalar = new List<Hasta>();
        }

        public void HastaEkle(Hasta hasta)
        {
            Hastalar.Add(hasta);
            Console.WriteLine($"Hasta {hasta.Ad} doktora ({Ad}) eklendi.");
        }
    }

    public class Hasta
    {
        public string Ad { get; set; }
        public string TCNo { get; set; }
        public Doktor Doktor { get; private set; }

        public void DoktorAtama(Doktor doktor)
        {
            Doktor = doktor;
            doktor.HastaEkle(this);
            Console.WriteLine($"{Ad} hastası doktora ({doktor.Ad}) atandı.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
