using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalisanDepartman
{


    public class Departman
    {
        public string Ad { get; set; }       
        public string Lokasyon { get; set; } 

        // Yapıcı metot
        public Departman(string ad, string lokasyon)
        {
            Ad = ad;
            Lokasyon = lokasyon;
        }
    }

    public class Calisan
    {
        public string Ad { get; set; }         
        public string Pozisyon { get; set; }   
        public Departman Departman { get; private set; }

        
        public Calisan(string ad, string pozisyon)
        {
            Ad = ad;
            Pozisyon = pozisyon;
        }

        
        public void DepartmanAtama(Departman departman)
        {
            Departman = departman;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
