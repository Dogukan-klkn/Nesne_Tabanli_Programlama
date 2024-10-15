using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//N'e Kadar Asal Sayıların Toplamı: Kullanıcıdan alınan N sayısına kadar olan tüm asal
//sayıların toplamını bulan bir program yazın.

namespace Asalsayi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N sayısını giriniz: ");
            int N = int.Parse(Console.ReadLine());
            AsalSayiHesabi(N);        
        }
        static void AsalSayiHesabi(int N)
        {
            int sayi = 2;
            int Asaltoplam = 0;
            while (sayi <= N) {
                

                if (Asalmi(sayi))
                {
                    Asaltoplam += sayi;
                    sayi++;
                }
                else
                {
                    sayi++;
                }
            }
            Console.WriteLine($"{N} sayısına kadar(N dahil) asal olan sayıların toplamı: {Asaltoplam} " );

            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadLine(); // Kullanıcı bir tuşa basana kadar bekle

        }
        static Boolean Asalmi(int sayi)
        {

            int bolen = 2;
            while (bolen <= Math.Sqrt(sayi))
            {
                if(sayi % bolen == 0)
                {
                    return false;
                }
                bolen++;
            }
            return true;
            

        }
    }
}
