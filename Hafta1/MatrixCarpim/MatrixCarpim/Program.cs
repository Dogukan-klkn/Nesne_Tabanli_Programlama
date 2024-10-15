using System;

class Program
{
    static void Main()
    {
        Console.Write("Matris boyutunu girin (NxN için N değeri): ");
        int boyut = int.Parse(Console.ReadLine());

        int[,] matris1 = new int[boyut, boyut];
        int[,] matris2 = new int[boyut, boyut];
        int[,] sonucMatris = new int[boyut, boyut];

        // Birinci matrisin elemanlarını al
        Console.WriteLine("Birinci matrisin elemanlarını girin:");
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write($"Matris1[{i},{j}] = ");
                matris1[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // İkinci matrisin elemanlarını al
        Console.WriteLine("İkinci matrisin elemanlarını girin:");
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write($"Matris2[{i},{j}] = ");
                matris2[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Eleman bazlı çarpma işlemini gerçekleştir
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                sonucMatris[i, j] = matris1[i, j] * matris2[i, j];
            }
        }

        // Sonucu ekrana yazdır
        Console.WriteLine("İki matrisin eleman bazlı çarpım sonucu:");
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.Write(sonucMatris[i, j] + "\t");
            }
            Console.WriteLine();
           
        }
        Console.ReadLine();
    }
}
