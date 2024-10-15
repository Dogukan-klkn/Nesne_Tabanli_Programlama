using System;
using System.Collections.Generic;

class Program
{
    // Labirentte geçerli adım olup olmadığını kontrol eden fonksiyon
    static bool GeçerliAdım(int[,] labirent, bool[,] ziyaretEdildi, int x, int y, int n)
    {
        // Hücrenin sınırlar içinde olup olmadığını ve yürünebilir (1) olup olmadığını kontrol ediyoruz
        return (x >= 0 && x < n && y >= 0 && y < n && labirent[x, y] == 1 && !ziyaretEdildi[x, y]);
    }

    // BFS ile en kısa yolu bulan fonksiyon
    static int EnKısaYol(int[,] labirent, int n)
    {
        // Dört yön için hareket vektörleri: yukarı, aşağı, sol, sağ
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        // Ziyaret edilen hücreleri takip eden 2D boolean dizisi
        bool[,] ziyaretEdildi = new bool[n, n];

        // Kuyruğa eklenen hücreler (x, y) ve o ana kadarki adım sayısı
        Queue<int[]> kuyruk = new Queue<int[]>();

        // Başlangıç noktasını kuyruğa ekliyoruz [x, y, adım]
        kuyruk.Enqueue(new int[] { 0, 0, 0 });
        ziyaretEdildi[0, 0] = true;

        while (kuyruk.Count > 0)
        {
            // Mevcut hücreyi al
            int[] mevcut = kuyruk.Dequeue();
            int x = mevcut[0];
            int y = mevcut[1];
            int adım = mevcut[2];

            // Eğer hedefe ulaşıldıysa adım sayısını döndür (adım + 1 demiyoruz)
            if (x == n - 1 && y == n - 1)
                return adım;

            // Dört yöne gitmeye çalış
            for (int i = 0; i < 4; i++)
            {
                int yeniX = x + dx[i];
                int yeniY = y + dy[i];

                // Eğer geçerli bir adımsa kuyruğa ekle
                if (GeçerliAdım(labirent, ziyaretEdildi, yeniX, yeniY, n))
                {
                    ziyaretEdildi[yeniX, yeniY] = true;
                    kuyruk.Enqueue(new int[] { yeniX, yeniY, adım + 1 });
                }
            }
        }

        // Eğer hazineye ulaşılamıyorsa
        return -1;
    }

    static void Main()
    {
        // Test için örnek labirent
        int[,] labirent = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 0, 1, 1, 1 },
            { 0, 0, 0, 1 }
        };

        int n = labirent.GetLength(0); // Labirentin boyutu
        int sonuç = EnKısaYol(labirent, n); // En kısa yolu hesapla

        if (sonuç != -1)
            Console.WriteLine("En Kısa Yol: " + sonuç + " adım");
        else
            Console.WriteLine("Yol Yok");

        // Programın hemen kapanmasını önlemek için
        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadLine();
    }
}
